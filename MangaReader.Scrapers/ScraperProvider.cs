using MangaReader.Scrapers.Exceptions;
using MangaReader.Utilities;

namespace MangaReader.Scrapers;

public class ScraperProvider : IScraperProvider
{
    private readonly IDictionary<string, IScraper> _map;
    private readonly HashSet<IScraper> _scrapers;

    public ScraperProvider(IEnumerable<IScraper> scrapers)
    {
        scrapers = scrapers.ToList();
        _map = scrapers.ToDistinctDictionary(x => x.Key, x => x);
        _scrapers = new HashSet<IScraper>(scrapers);
    }

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
        catch (InvalidOperationException e)
        {
            throw new NoValidScraperException($"No manga providers enabled for URL {url}. Double check the URL was typed correctly. If it was, please report this as a bug.");
        }
    }
}