namespace Models
{
    public interface IChapter
    {
        string[] PageFilenames { get; }

        int PageCount { get; }
        
        string PreviewImagePath { get; }

        string GetPagePath(int pageNumber);
    }
}