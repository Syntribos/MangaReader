namespace MangaReader.Scrapers.Exceptions;

public class NoValidScraperException : Exception
{
    public NoValidScraperException(string message)
    : base(message)
    {
    }
}