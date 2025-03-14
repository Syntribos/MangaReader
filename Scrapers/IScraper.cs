using Models;
using System.Text.RegularExpressions;

namespace Scrapers;

public interface IScraper : IEquatable<IScraper>
{
    string Key { get; }
    
    Regex UrlPattern { get; }

    public bool AddManga(string url);

    public Task<IEnumerable<ISeriesPreview>> Search<T>(T query);
}