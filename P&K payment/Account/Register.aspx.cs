using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using P_K_payment;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;
using System.Text;
using System.ServiceModel.Channels;

public partial class Account_Register : Page
{
    private readonly HttpService _httpservice;

    public Account_Register()
    {
        _httpservice = new HttpService();
    }

    protected async void CreateUser_Click(object sender, EventArgs e)
    {
        ClientViewModel client = new ClientViewModel();
        client.FirstName = Name.Text;
        client.LastName = LastName.Text;
        client.Login = Login.Text;
        client.Phone = PhoneNumber.Text;
        client.Email = Email.Text;

        string jsonData = JsonConvert.SerializeObject(client);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await _httpservice.RegistrationResponse("http://localhost:5239/register", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Ok");
                Response.Redirect("UserPage.aspx");
            }
            else
            {
                Console.WriteLine("BAD VERY BAD");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("HERE IS THE ERROR" + ex.StackTrace);
        }
    }
}


        /*var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }*/

 

   /* public override void VerifyRenderingInServerForm(Control control)
    {

    }*/
