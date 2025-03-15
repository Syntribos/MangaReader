using Utilities;
using Scrapers.Exceptions;

namespace Scrapers;

public class ScraperProvider(IEnumerable<IScraper> scrapers) : IScraperProvider
{
    private readonly IDictionary<string, IScraper> _map = scrapers.ToDistinctDictionary(x => x.Key, x => x);
    private readonly HashSet<IScraper> _scrapers = [.. scrapers];

    public IScraper GetByKey(string key)
    {
        if (_map.TryGetValue(key, out var scraper))
        {
            return scraper;
        }

        throw new NoValidScraperException($"Scraper {key} does not exist.");
    }

    public IScraper GetByUrl(string url)
    {
        try
        {
            return _scrapers.First(x => x.UrlPattern.IsMatch(url));
        }
        catch (InvalidOperationException)
        {
            throw new NoValidScraperException($"No manga providers enabled for URL {url}. Double check the URL was typed correctly. If it was, please report this as a bug.");
        }
    }
}
