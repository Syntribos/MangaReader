using MangaReader.DataManager;
using MangaReader.Utilities;

namespace MangaReader.Scrapers;

public class Scraper : IScraper
{
    private readonly IDatabaseQuerier _querier;

    public Scraper(IDatabaseQuerier querier, string key)
    {
        Contract.RequireNotNull(querier, nameof(querier));
        Contract.RequireNotNullOrEmpty(key);

        _querier = querier;
        Key = key;
    }
    
    public string Key { get; }
}