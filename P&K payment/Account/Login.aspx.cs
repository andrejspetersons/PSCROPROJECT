using System;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

public partial class Account_Login : Page
{
    private readonly HttpService _httpservice;

    public Account_Login()
    {
        _httpservice = new HttpService();
    }

    protected async void LogIn(object sender, EventArgs e)
    {
        string username = UserNameTextBox.Text;

        string jsonData = JsonConvert.SerializeObject(username);

        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await _httpservice.LoginRespone("http://localhost:5239/login", content);
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Session.Add("UserName", username);
                Response.Redirect("UserPage.aspx");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("HERE IS THE ERROR" + ex.StackTrace);
        }
    }
}
    
