using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using P_K_payment;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

public partial class Account_Login : Page
{
       /* protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }*/

    protected async void LogIn(object sender, EventArgs e)
    {
        UserLoginViewModel userlog = new UserLoginViewModel();
        userlog.UserName = UserName.Text;

        string jsonData = JsonConvert.SerializeObject(userlog);
        

        using (HttpClient httpClient=HttpClientFactory.CreateClient())
        {
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            try
            {
            HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5239/login", content);
                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Current.Session.Add("UserName", UserName.Text);
                    Response.Redirect("UserPage.aspx");    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HERE IS THE ERROR" + ex.StackTrace);
            }
        }
    }

}