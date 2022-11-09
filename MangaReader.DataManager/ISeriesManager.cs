using MangaReader.Models;

namespace MangaReader.DataManager;

public interface ISeriesManager
{
    IEnumerable<ISeriesPreview> GetAllMangaPreviews();

    ISeries BuildSeriesFromPreview(ISeriesPreview preview);

    IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex);
}