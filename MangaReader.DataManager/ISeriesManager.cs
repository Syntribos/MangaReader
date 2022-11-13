using System.Collections.Generic;
using System.Threading;
using MangaReader.Models;

namespace MangaReader.DataManager;

public interface ISeriesManager
{
    IEnumerable<ISeriesPreview> GetAllMangaPreviews(CancellationToken cancellationToken);

    ISeries BuildSeriesFromPreview(ISeriesPreview preview);

    IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex);
}