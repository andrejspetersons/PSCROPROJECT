using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Activities;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_UserPage : Page
{
    protected async void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = HttpContext.Current.Session["UserName"] as string;
            if (username != null)
            {
                Greeting.InnerText = "Hello, " + username+"!";
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

    private void BindGrid()
    {
        string connectionString = "Data Source=.;Initial Catalog=PSI_CRO_DB;Integrated Security=True;";
        using (SqlConnection con=new SqlConnection(connectionString))
        {
            using(SqlCommand cmd=new SqlCommand
            (
                "SELECT s.Name AS ServiceName,"+
                "pb.Id AS PaymentBillId,"+
                "pb.Amount AS Amount,"+
                "pb.IssueDate AS IssueDate,"+
                "pb.DueToDate AS DueToDate,"+
                "pb.PaymentDate AS PaymentDate,"+
                "pb.PaymentReceipt AS PaymentReceipt,"+
                "pb.PaymentStatus AS PaymentStatus "+
                "FROM PaymentBills pb "+
                "JOIN CompanyServices s ON pb.ServiceId = s.Id"
                )
            )
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using(DataTable dt=new DataTable())
                    {
                        sda.Fill(dt);
                        PaymentBill.DataSource = dt;
                        PaymentBill.DataBind();
                        
                    }
                }
            }
                
        }
    }

    protected void OnRowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button paymentButton = (Button)e.Row.FindControl("btnPay");
            string paymentReceipt = DataBinder.Eval(e.Row.DataItem, "PaymentReceipt")?.ToString();
            if (string.IsNullOrEmpty(paymentReceipt) || Convert.ToInt32(paymentReceipt) == 0)
            {
                paymentButton.Visible = false;
            }
            else
            {
                paymentButton.Visible = true;
            }
        }
    }

    protected void OnRowEditing(object sender,GridViewEditEventArgs e)
    {
        PaymentBill.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void OnRowUpdating(object sender,GridViewUpdateEventArgs e)
    {
        GridViewRow row = PaymentBill.Rows[e.RowIndex];
        int id = Convert.ToInt32(PaymentBill.DataKeys[e.RowIndex].Values[0]);
        int test = row.Cells.Count;
        int receipt = Convert.ToInt32((row.Cells[7].Controls[0] as TextBox).Text);

        string connectionString = "Data Source=.;Initial Catalog=PSI_CRO_DB;Integrated Security=True;";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE PaymentBills SET PaymentReceipt=@receipt WHERE Id=@paymentbillId",con))
                {
                    cmd.Parameters.AddWithValue("@paymentbillId", id);
                    cmd.Parameters.AddWithValue("@receipt", receipt);
                    con.Open();                
                    cmd.ExecuteNonQuery();
                }
            }

            BindGrid();
        }
        catch (Exception ex)
        {
           
        }
        

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
            string[] arguments = argument.Split(',');
            int paymentBillId = Convert.ToInt32(arguments[0]);
            int receipt = Convert.ToInt32(arguments[1]);

            string json = JsonConvert.SerializeObject(receipt);

            using (HttpClient httpclient = HttpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpclient.PutAsync($"http://localhost:5239/paymentbill/{paymentBillId}", content);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("PUT request successful");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
    }

}