using System.Collections.Generic;

namespace MangaReader.Models;

public interface ISeriesPreview
{
        string Title { get; }

        string PreviewImagePath { get; }

        ISeries ToSeries(HashSet<IChapterPreview> chapterPreviews);
}