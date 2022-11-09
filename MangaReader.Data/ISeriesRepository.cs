using System.Collections.Generic;
using MangaReader.Models;

namespace MangaReader.Data;

public interface ISeriesRepository
{
    IEnumerable<ISeriesPreview> GetAllMangaPreviews();

    ISeries BuildSeriesFromPreview(ISeriesPreview preview);

    IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex);
}