using Models;

namespace DataManager;

public interface ISeriesManager
{
    IEnumerable<ISeriesPreview> GetAllMangaPreviews(CancellationToken cancellationToken);

    ISeries BuildSeriesFromPreview(ISeriesPreview preview);

    IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex);
}