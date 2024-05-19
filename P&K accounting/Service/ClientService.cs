using P_K_accounting.Models;
using System.Text;
using System.Text.Json;

namespace P_K_accounting.Service
{
    public class ClientService
    {
        private readonly HttpService _httpService;
        public ClientService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<string>> GetClientListAsync()
        {
            HttpResponseMessage response = await _httpService.GetClientList("http://localhost:5239/clients");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(responseContent);
        }

        public async Task<IEnumerable<PaymentBillAccountantViewModel>> GetClientPaymentBillsAsync(string clientName)
        {

            HttpResponseMessage response = await _httpService.GetClientPayments($"http://localhost:5239/paymentbill/{clientName}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<PaymentBillAccountantViewModel>>(responseContent);
        }

        public async Task<HttpResponseMessage> AddPaymentAsync(string clientName, PaymentBillAccountantViewModel pbvm)
        {
            string json = JsonSerializer.Serialize(pbvm);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpService.AddPayment($"http://localhost:5239/paymentbill/{clientName}", content);
        }

        public async Task<HttpResponseMessage> UpdateClientByIdAsync(int id, PaymentBillAccountantViewModel pbvm)
        {
            string json = JsonSerializer.Serialize(pbvm);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpService.UpdateClientById($"http://localhost:5239/paymentbill/{id}", content);
        }

        public async Task<HttpResponseMessage> DeletePaymentBillAsync(int id)
        {
            return await _httpService.DeletePaymentBill($"http://localhost:5239/paymentbill/{id}");
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
    }
}