using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

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