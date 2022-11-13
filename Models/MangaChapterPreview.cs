using System.IO;

namespace Models;

public class MangaChapterPreview : IChapterPreview
{
    private readonly string _basePath;
    private readonly string _previewImageFilename;

    public MangaChapterPreview(string chapterName, int chapterNumber, int pageCount, string basePath, string previewImageFilename)
    {
        _basePath = basePath;
        _previewImageFilename = previewImageFilename;
        
        ChapterName = chapterName;
        ChapterNumber = chapterNumber;
        PageCount = pageCount;

        PreviewImagePath = Path.Combine(_basePath, previewImageFilename);
    }
    
    public string ChapterName { get; }
    
    public int ChapterNumber { get; }

    public int PageCount { get; }

    public string PreviewImagePath { get; }

    public IChapter ToChapter(string[] pageFilenames)
    {
        return new MangaChapter(ChapterName, ChapterNumber, _basePath, pageFilenames, _previewImageFilename);
    }
}