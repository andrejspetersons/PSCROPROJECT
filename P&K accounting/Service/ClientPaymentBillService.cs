using P_K_accounting.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace P_K_accounting.Service
{
    public class ClientPaymentBillService
    {
        private readonly HttpService_PaymentBills _httpService;
        public ClientPaymentBillService(HttpService_PaymentBills httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<string>> GetClientListAsync()
        {
            HttpResponseMessage response = await _httpService.GetClientList("http://localhost:5239/client-api/clientslogins");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new List<string>();
            }

            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(responseContent);
        }

        public async Task<List<PaymentBillAccountantViewModel>> GetClientPaymentBillsAsync(string clientName)
        {

            HttpResponseMessage response = await _httpService.GetClientPayments($"http://localhost:5239/payment-api/paymentbill/{clientName}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new List<PaymentBillAccountantViewModel>();
            }

            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<PaymentBillAccountantViewModel>>(responseContent);
        }

        public async Task<HttpResponseMessage> AddPaymentAsync(string clientName, PaymentBillAccountantViewModel pbvm)
        {
            string json = JsonSerializer.Serialize(pbvm);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpService.AddPayment($"http://localhost:5239/payment-api/paymentbill/{clientName}", content);
        }

        public async Task<HttpResponseMessage> UpdateClientBillByIdAsync(int id, PaymentBillAccountantViewModel pbvm)
        {
            string json = JsonSerializer.Serialize(pbvm);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpService.UpdateClientBillById($"http://localhost:5239/payment-api/paymentbill/{id}", content);
        }

        public async Task<HttpResponseMessage> DeletePaymentBillAsync(int id)
        {
            return await _httpService.DeletePaymentBill($"http://localhost:5239/payment-api/paymentbill/{id}");
        }

        public async Task<IEnumerable<PaymentBillAccountantViewModel>> OrderClientBillsAsync(string columnName, string clientName)
        {
            var json = JsonSerializer.Serialize(clientName);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpService.OrderBillsByColumnName($"http://localhost:5239/orderby/{columnName}", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<PaymentBillAccountantViewModel>>(responseContent);
        }

       //get service names
    }
}