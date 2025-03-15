using System;
using System.Collections.Generic;

namespace Models;

public class SeriesPreview(Guid id, string title, string previewImagePath, int chapterCount, int unreadChapterCount) : ISeriesPreview
{
    public SeriesPreview(Guid id, string title, string previewImagePath, int chapterCount)
    : this(id, title, previewImagePath, chapterCount, chapterCount)
    {
    }

    public Guid Id { get; } = id;

    public string Title { get; } = title;

    public string PreviewImagePath { get; } = previewImagePath;

    public int ChapterCount { get; } = chapterCount;

    public int UnreadChapterCount { get; } = unreadChapterCount;

    public ISeries ToSeries(HashSet<IChapterPreview> chapterPreviews)
    {
        return new Series(chapterPreviews, this);
    }
}