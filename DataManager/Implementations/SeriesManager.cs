using Data;
using Models;
using Utilities;

namespace DataManager.Implementations;

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
        return SeriesFactory.EmptySeries;
    }

    public IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex)
    {
        throw new NotImplementedException();
    }
}