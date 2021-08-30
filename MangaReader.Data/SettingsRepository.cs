using MangaReader.Data.Interfaces;

namespace MangaReader.Data
{
    public class SettingsRepository : DataRepository, ISettingsRepository
    {
        public SettingsRepository(string databasePath)
            : base(databasePath)
        {
        }
    }
}