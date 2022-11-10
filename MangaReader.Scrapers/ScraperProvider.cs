namespace MangaReader.Scrapers;

public class ScraperProvider : IScraperProvider
{
    private readonly Dictionary<string, IScraper> _map;
    private readonly HashSet<IScraper> _scrapers;

    public ScraperProvider(
        MangaDexScraper mangaDexScraper)
    {
        _scrapers = new HashSet<IScraper> { mangaDexScraper };
        _map = _scrapers.ToDictionary(x => x.Key, x => x);
    }

    public IScraper GetByKey(string key)
    {
        if (_map.TryGetValue(key, out var scraper))
        {
            return scraper;
        }

        throw new NotSupportedException($"Scraper {key} does not exist.");
    }
}