using System.Net.Http;

/// <summary>
/// Summary description for HttpClientFactory
/// </summary>
public class HttpClientFactory
{
    public static HttpClient CreateClient()
    {
        return new HttpClient();
    }
}