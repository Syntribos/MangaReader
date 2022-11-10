using MangaReader.DataManager;
using MangaReader.Utilities;

namespace MangaReader.Scrapers;

public class MangaDexScraper : Scraper
{
    public MangaDexScraper(IDatabaseQuerier querier)
    : base(querier, nameof(MangaDexScraper))
    {
    }
}