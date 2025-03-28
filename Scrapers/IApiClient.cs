namespace Scrapers;
public interface IApiClientProvider
{
    public HttpClient GetClient();
}
