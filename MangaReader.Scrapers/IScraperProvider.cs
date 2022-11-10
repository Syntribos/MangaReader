namespace MangaReader.Scrapers;

public interface IScraperProvider
{
    IScraper GetByKey(string key);

    IScraper GetByUrl(string url);
}