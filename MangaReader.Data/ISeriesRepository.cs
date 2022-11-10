using System.Collections.Generic;
using System.Threading;
using MangaReader.Models;

namespace MangaReader.Data;

public interface ISeriesRepository
{
    IEnumerable<ISeriesPreview> GetAllMangaPreviews(CancellationToken cancellationToken);

    ISeries BuildSeriesFromPreview(ISeriesPreview preview, CancellationToken cancellationToken);

    IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex, CancellationToken cancellationToken);
}