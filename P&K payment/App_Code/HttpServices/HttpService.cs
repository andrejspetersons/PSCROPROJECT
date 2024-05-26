using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Summary description for HttpService
/// </summary>
public class HttpService
{
    private readonly HttpClient _httpClient;
    public HttpService()
    {
        _httpClient=HttpClientFactory.CreateClient(); 
    }

    public async Task<HttpResponseMessage> LoginRespone(string url,StringContent content)
    {
        return await _httpClient.PostAsync(url, content);
    }

    public async Task<HttpResponseMessage> GetPaymentBills(string url)
    {
        return await _httpClient.GetAsync(url);
    }

    public async Task<HttpResponseMessage> PayTheBillResponse(string url,StringContent content)
    {
        return await _httpClient.PutAsync(url,content);
    }

    public async Task<HttpResponseMessage> UpdateReceipt(string url, StringContent content)
    {
        return await _httpClient.PutAsync(url, content);
    }
}