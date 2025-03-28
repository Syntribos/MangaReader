using Scrapers.MangaDex;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Scrapers;

public class ApiClientProvider(IVersionProvider versionProvider) : IApiClientProvider
{
    private bool _initialized = false;
    private HttpClient? _httpClient;

    public HttpClient GetClient()
    {
        if (_initialized && _httpClient is not null)
        {
            return _httpClient;
        }

        _httpClient = new HttpClient();
        _httpClient = Init(_httpClient ?? new HttpClient());
        return _httpClient;
    }

    private HttpClient Init([NotNull]HttpClient? client = null)
    {
        if (client == null)
        {
            client = new HttpClient();
        }

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
        client.BaseAddress = new Uri(ApiConstants.API_URL);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var userAgent = new ProductInfoHeaderValue(
            new ProductHeaderValue(versionProvider.ProductName, versionProvider.VersionNumber)
        );
        client.DefaultRequestHeaders.UserAgent.Add(userAgent);

        _initialized = true;
        return client;
    }
}
