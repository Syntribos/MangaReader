using System.Collections.Generic;
using MangaReader.Models;

namespace MangaReader.Data.Interfaces
{
    public interface ISeriesRepository
    {
        IEnumerable<ISeries> GetMangaForCategory(int categoryIndex);
    }
}