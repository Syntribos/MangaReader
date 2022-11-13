using System;
using System.Collections.Generic;

namespace Models;

public class SeriesPreview : ISeriesPreview
{
    public SeriesPreview(Guid id, string title, string previewImagePath, int chapterCount, int unreadChapterCount)
    {
        Id = id;
        Title = title;
        PreviewImagePath = previewImagePath;
        ChapterCount = chapterCount;
        UnreadChapterCount = unreadChapterCount;
    }

    public Guid Id { get; }

    public string Title { get; }

    public string PreviewImagePath { get; }
    
    public int ChapterCount { get; }
    
    public int UnreadChapterCount { get; }

    public ISeries ToSeries(HashSet<IChapterPreview> chapterPreviews)
    {
        return new Series(chapterPreviews, this);
    }
}