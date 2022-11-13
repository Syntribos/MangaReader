using System.Collections.Generic;
using System.Threading;
using Models;

namespace Data;

public interface ISeriesRepository
{
    IEnumerable<ISeriesPreview> GetAllMangaPreviews(CancellationToken cancellationToken);

    ISeries BuildSeriesFromPreview(ISeriesPreview preview, CancellationToken cancellationToken);

    IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex, CancellationToken cancellationToken);
}