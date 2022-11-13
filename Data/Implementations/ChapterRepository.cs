namespace Data.Implementations
{
    public class ChapterRepository : DataRepository, IChapterRepository
    {
        public ChapterRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }
    }
}