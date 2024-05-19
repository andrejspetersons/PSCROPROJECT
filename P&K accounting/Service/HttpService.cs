namespace P_K_accounting.Service
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        public HttpService()
        {
            _httpClient = new HttpClient();    
        }

        public async Task<HttpResponseMessage> GetClientList(string url)
        {
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> GetClientPayments(string url)
        {
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> AddPayment(string url,StringContent content)
        {
            return await _httpClient.PostAsync(url,content);
        }

        public async Task<HttpResponseMessage> UpdateClientById(string url,StringContent content)
        {
            return await _httpClient.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeletePaymentBill(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> OrderBillsByColumnName(string url,StringContent content)
        {
            return await _httpClient.PostAsync(url, content);
        }
    }
}
