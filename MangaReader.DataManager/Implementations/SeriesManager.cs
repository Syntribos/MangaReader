using MangaReader.Data;
using MangaReader.Models;
using MangaReader.Utilities;

namespace MangaReader.DataManager.Implementations;

public class SeriesManager : ISeriesManager
{
    private readonly ISeriesRepository _seriesRepository;

    public SeriesManager(ISeriesRepository seriesRepository)
    {
        Contract.RequireNotNull(seriesRepository, nameof(seriesRepository));

        _seriesRepository = seriesRepository;
    }

    public IEnumerable<ISeriesPreview> GetAllMangaPreviews(CancellationToken cancellationToken)
    {
        return _seriesRepository.GetAllMangaPreviews(cancellationToken);
    }

    public ISeries BuildSeriesFromPreview(ISeriesPreview preview)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex)
    {
        throw new NotImplementedException();
    }
}