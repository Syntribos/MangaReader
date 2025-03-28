using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.RegularExpressions;
using DataManager;
using Models;
using Utilities;
using System.Reflection;
using System.Net;
using Scrapers.MangaDex.ApiObjects;
using System.Text.Json;

namespace Scrapers.MangaDex;

public class MangaDexScraper : IScraper
{
    private readonly IDatabaseQuerier _querier;
    private readonly IApiClientProvider _clientProvider;

    public MangaDexScraper(IDatabaseQuerier querier, IApiClientProvider clientProvider)
    {
        Contract.RequireNotNull(querier, nameof(querier));

        _querier = querier;
        _clientProvider = clientProvider;
    }

    public string Key => nameof(MangaDexScraper);

    public Regex UrlPattern => new Regex(@"mangadex\.org", RegexOptions.IgnoreCase);

    public bool AddManga(string url)
    {
        var match = UrlPattern.Match(url);
        if (match.Success)
        {
            var mangaKey = Guid.Parse(match.Groups.Values.Last().ToString());
        }

        return false;
    }

    // This is pretty untestable. Maybe implement a proper search pipeline?
    // Query > endpoint > result manipualtion/parsing?
    public async Task<IEnumerable<ISeriesPreview>> Search<T>(T query)
    {
        var client = _clientProvider.GetClient();
        var res = await client.GetAsync("/manga?limit=1");
        string result = string.Empty;
        MangaResponse? mangaResults = null;
        IEnumerable<ISeriesPreview>? mangaList = null;
        if (res.IsSuccessStatusCode)
        {
            result = await res.Content.ReadAsStringAsync();
            mangaResults = JsonSerializer.Deserialize<MangaResponse>(result);
            mangaList = mangaResults?.ToSeriesPreviews().ToList() ?? [];
        }
        
        return mangaList ?? [];
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
