using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_UserPage : Page
{
    private readonly HttpService _httpservice;

    public Account_UserPage()
    {
        _httpservice = new HttpService();
    }

    protected async void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = HttpContext.Current.Session["UserName"] as string;
            if (username != null)
            {
                Greeting.InnerText = "Hello, " + username + "!";
                BindGrid();

            }

        }
        else
        {
            if (Session["UserName"] != null)
            {

            }
            else
            {

            }
        }
    }

    private async void BindGrid()
    {
        using (HttpClient httpClient = HttpClientFactory.CreateClient())
        {
            HttpResponseMessage response = await _httpservice.GetPaymentBills($"http://localhost:5239/paymentbills/{Session["UserName"]}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var paymentBillList = JsonConvert.DeserializeObject<IEnumerable<PaymentBillUserViewModel>>(content);
                PaymentBill.DataSource = paymentBillList;
                ViewState["billtable"] = paymentBillList;
                PaymentBill.DataBind();
            }
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button paymentButton = (Button)e.Row.FindControl("btnPay");
            string paymentReceipt = DataBinder.Eval(e.Row.DataItem, "PaymentReceipt")?.ToString();
            DateTime? paymentDate = DataBinder.Eval(e.Row.DataItem, "PaymentDate") as DateTime?;
            DateTime dueDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DueToDate"));

            if (string.IsNullOrEmpty(paymentReceipt) || Convert.ToInt32(paymentReceipt) == 0)
            {
                paymentButton.Visible = false;
            }
            else
            {
                paymentButton.Visible = true;
            }

            if (paymentDate.HasValue && dueDate.Date < paymentDate.Value.Date)
            {
                e.Row.BackColor = Color.FromArgb(255, 87, 87);
            }

        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        PaymentBill.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected async void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = PaymentBill.Rows[e.RowIndex];
        int id = Convert.ToInt32(PaymentBill.DataKeys[e.RowIndex].Values[0]);
        int receipt = Convert.ToInt32((row.Cells[7].Controls[0] as TextBox).Text);

        string jsonData = JsonConvert.SerializeObject(receipt);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await _httpservice.UpdateReceipt($"http://localhost:5239/updatereceipt/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.WriteLine("Not Good");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("HERE IS THE ERROR" + ex.StackTrace);
        }

        BindGrid();

    }


    protected void OnRowCancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        PaymentBill.EditIndex = -1;
        BindGrid();
    }

    protected async void PayBillCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "PayBill")
        {
            string argument = e.CommandArgument.ToString();
            int paymentBillId = Convert.ToInt32(argument);
            string json = JsonConvert.SerializeObject("");

            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await _httpservice.PayTheBillResponse($"http://localhost:5239/paybill/{paymentBillId}",content);
                
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("PUT request successful");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            BindGrid();//!!
        }
    }

    protected void PaymentBill_Sorting(object sender, GridViewSortEventArgs e)
    {
        var paymentBillList = (IEnumerable<PaymentBillUserViewModel>)ViewState["billtable"];
        string sortExpression = e.SortExpression;
        switch (sortExpression.ToLower())
        {
            case "servicename":
                paymentBillList = paymentBillList.OrderBy(item => item.ServiceName);
                    break;
            case "amount":
                paymentBillList = paymentBillList.OrderBy(item => item.Amount);
                break;
            case "issuedate":
                paymentBillList = paymentBillList.OrderBy(item => item.IssueDate);
                break;
            case "duetodate":
                paymentBillList = paymentBillList.OrderBy(item => item.DueToDate);
                break;
            case "paymentdate":
                paymentBillList = paymentBillList.OrderBy(item => item.PaymentDate);
                break;
            case "paymentstatus":
                paymentBillList = paymentBillList.OrderBy(item => item.PaymentStatus);
                break;
            default:
                break;
        }

        PaymentBill.DataSource = paymentBillList;
        PaymentBill.DataBind();
    }
}
