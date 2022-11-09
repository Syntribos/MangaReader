using MangaReader.Utilities;

namespace MangaReader.DataManager.Implementations;

public class Manager : IManager
{
    public Manager(ISeriesManager seriesManager)
    {
        Contract.RequireNotNull(seriesManager, nameof(seriesManager));

        SeriesManager = seriesManager;
    }

    public ISeriesManager SeriesManager { get; }
}