using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for ClientService
/// </summary>
public class ClientService
{
    private readonly HttpService _httpService;
    public ClientService(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<HttpResponseMessage> PayBillAsync(int id)
    {
        string json = JsonConvert.SerializeObject("");
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");     
        return await _httpService.PayTheBillResponse($"http://localhost:5239/client-api/paybill/{id}", content);
    }
    
    public async Task<HttpResponseMessage> UpdateReceiptAsync(int id,string receipt)
    {
        string json = JsonConvert.SerializeObject(receipt);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpService.UpdateReceipt($"http://localhost:5239/payment-api/updatereceipt/{id}", content);
    }

    public async Task<List<PaymentBillUserViewModel>> GetPaymentBillsAsync(string username)
    {
        HttpResponseMessage response = await _httpService.GetPaymentBills($"http://localhost:5239/client-api/paymentbills/{username}");
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PaymentBillUserViewModel>>(content);
        }
        else
        {
            return new List<PaymentBillUserViewModel>();
        }
    }
}