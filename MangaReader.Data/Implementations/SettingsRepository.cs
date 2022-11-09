namespace MangaReader.Data.Implementations;

public class SettingsRepository : DataRepository, ISettingsRepository
{
    public SettingsRepository(IConnectionStringProvider connectionStringProvider)
        : base(connectionStringProvider)
    {
    }
}
