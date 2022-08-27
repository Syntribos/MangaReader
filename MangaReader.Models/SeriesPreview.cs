using System.Collections.Generic;

namespace MangaReader.Models;

public class SeriesPreview : ISeriesPreview
{
    public SeriesPreview(string title, string previewImagePath, int chapterCount, int unreadChapterCount)
    {
        Title = title;
        PreviewImagePath = previewImagePath;
        ChapterCount = chapterCount;
        UnreadChapterCount = unreadChapterCount;
    }

    public string Title { get; }

    public string PreviewImagePath { get; }
    
    public int ChapterCount { get; }
    
    public int UnreadChapterCount { get; }

    public ISeries ToSeries(HashSet<IChapterPreview> chapterPreviews)
    {
        return new Series(chapterPreviews, this);
    }
}