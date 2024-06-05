using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_UserPage : Page
{
    private readonly ClientService _clientservice;
    private readonly UIHelper _helper;

    public Account_UserPage()
    {
        _clientservice = new ClientService(new HttpService());
        _helper = new UIHelper();
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
        var paymentBillList = await _clientservice.GetPaymentBillsAsync(Session["UserName"] as string);
        PaymentBill.DataSource = paymentBillList;
        ViewState["billtable"] = paymentBillList;
        if (ViewState["sortDirection"] == null)
        {
            ViewState["sortDirection"] = "ASC";
        }

        PaymentBill.DataBind();
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
        string receipt = (row.Cells[7].Controls[0] as TextBox).Text;
        HttpResponseMessage response = await _clientservice.UpdateReceiptAsync(id, receipt);

        if (response.IsSuccessStatusCode)
        {
            Response.Write("<script>alert('Receipt was updated successfully')</script");
        }
        else
        {
            string errorMessage = await response.Content.ReadAsStringAsync();
            var errors = JsonConvert.DeserializeObject<List<string>>(errorMessage);
            Response.Write("<script>alert('" + string.Join("\n", errors) + "')</script");
        }
        PaymentBill.EditIndex = -1;
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
            HttpResponseMessage response = await _clientservice.PayBillAsync(paymentBillId);
                
            if (response.IsSuccessStatusCode)
            {
                Response.Write("<script>alert('Bill was payed successfully')</script");
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<List<string>>(errorMessage);
                Response.Write("<script>alert('" + string.Join("\n", errors) + "')</script");
            }
            BindGrid();
        }
    }

    protected void PaymentBill_Sorting(object sender, GridViewSortEventArgs e)
    {
        var paymentBillList = (IEnumerable<PaymentBillUserViewModel>)ViewState["billtable"];
        string sortExpression = e.SortExpression;
        string sortDirection = ViewState["sortDirection"].ToString();
        PaymentBill.DataSource = _helper.SortData(paymentBillList, sortExpression, sortDirection);
        PaymentBill.DataBind();
        ViewState["sortDirection"] = sortDirection == "ASC" ? "DESC" : "ASC";
    }
}
