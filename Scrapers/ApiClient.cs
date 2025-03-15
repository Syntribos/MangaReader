using Scrapers.MangaDex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Scrapers;

public class ApiClient(IVersionProvider versionProvider) : HttpClient
{
    public void Init()
    {
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
        BaseAddress = new Uri(ApiConstants.API_URL);
        DefaultRequestHeaders.Accept.Clear();
        DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var userAgent = new ProductInfoHeaderValue(
            new ProductHeaderValue(versionProvider.ProductName, versionProvider.VersionNumber)
        );
        DefaultRequestHeaders.UserAgent.Add(userAgent);
    }
}
