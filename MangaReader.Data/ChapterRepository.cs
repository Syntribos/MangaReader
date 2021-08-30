using MangaReader.Data.Interfaces;

namespace MangaReader.Data
{
    public class ChapterRepository : DataRepository, IChapterRepository
    {
        public ChapterRepository(string databasePath)
            : base(databasePath)
        {
        }
    }
}