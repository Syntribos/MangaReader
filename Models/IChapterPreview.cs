namespace Models;

public interface IChapterPreview
{
    string ChapterName { get; }
    
    int ChapterNumber { get; }

    int PageCount { get; }

    string PreviewImagePath { get; }

    IChapter ToChapter(string[] pageFilenames);
}