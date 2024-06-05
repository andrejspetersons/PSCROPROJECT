namespace P_K_accounting.Service.HttpServices
{
    public class HttpService_Clients
    {
        private readonly HttpClient _httpClient;
        public HttpService_Clients()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> AddClientAsync(string url, StringContent content)
        {
            return await _httpClient.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> GetClientsAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> UpdateClientAsync(string url, StringContent content)
        {
            return await _httpClient.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeleteClientAsync(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }
    }
}
