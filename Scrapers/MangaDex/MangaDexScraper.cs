using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.RegularExpressions;
using DataManager;
using Models;
using Utilities;
using System.Reflection;
using System.Net;

namespace Scrapers.MangaDex;

public class MangaDexScraper : IScraper
{
    private readonly IDatabaseQuerier _querier;
    private static readonly HttpClient _client = new();

    public MangaDexScraper(IDatabaseQuerier querier)
    {
        Contract.RequireNotNull(querier, nameof(querier));

        _querier = querier;
    }

    public string Key => nameof(MangaDexScraper);

    public Regex UrlPattern => new Regex(@"mangadex\.org\/title\/([^\W_]{8}-[^\W_]{4}-[^\W_]{4}-[^\W_]{4}-[^\W_]{12})\/[\w-]*", RegexOptions.IgnoreCase);

    public bool AddManga(string url)
    {
        var match = UrlPattern.Match(url);
        if (match.Success)
        {
            var mangaKey = Guid.Parse(match.Groups.Values.Last().ToString());
        }

        return false;
    }

    public async Task<IEnumerable<ISeriesPreview>> Search<T>(T query)
    {
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
        _client.BaseAddress = new Uri(ApiConstants.API_URL);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var userAgent = new ProductInfoHeaderValue(new ProductHeaderValue("JessMangaReader", "a0.0.1"));
        _client.DefaultRequestHeaders.UserAgent.Add(userAgent);

        var res = await _client.GetAsync("/manga?limit=1");
        string result = string.Empty;
        if (res.IsSuccessStatusCode)
        {
            result = await res.Content.ReadAsStringAsync();
        }
        Console.WriteLine(result);
        return new List<ISeriesPreview> { new SeriesPreview(Guid.NewGuid(), "Test", "TestPath", 12, 12) };
    }

    public bool Equals(IScraper? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is IScraper other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }
}