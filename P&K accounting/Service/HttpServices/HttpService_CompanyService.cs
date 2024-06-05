namespace P_K_accounting.Service.HttpServices
{
    public class HttpService_CompanyService
    {
        private readonly HttpClient _httpClient;
        public HttpService_CompanyService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAllServices(string url)
        {
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> AddNewService(string url, StringContent content)
        {
            return await _httpClient.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> UpdateServiceById(string url, StringContent content)
        {
            return await _httpClient.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeleteServiceById(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> GetServiceList(string url)
        {
            return await _httpClient.GetAsync(url);
        }

    }
}
