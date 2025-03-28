using DataManager;
using NSubstitute;
using Scrapers;
using Scrapers.MangaDex;

namespace ScrapersTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var apiClientProvider = Substitute.For<IApiClientProvider>();
        var dbQuerier = Substitute.For<IDatabaseQuerier>();

        apiClientProvider.GetClient().Returns(new HttpClient());

        var mangaDexScraper = new MangaDexScraper(dbQuerier, apiClientProvider);
    }
}