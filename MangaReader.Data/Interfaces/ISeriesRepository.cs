using System.Collections.Generic;
using MangaReader.Models;

namespace MangaReader.Data.Interfaces
{
    public interface ISeriesRepository
    {
        IEnumerable<ISeriesPreview> GetAllMangaPreviews();

        IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex);
    }
}