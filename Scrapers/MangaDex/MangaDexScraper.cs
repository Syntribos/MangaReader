using System.Text.RegularExpressions;
using DataManager;
using Utilities;

namespace Scrapers.MangaDex;

public class MangaDexScraper : IScraper
{
    private readonly IDatabaseQuerier _querier;

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