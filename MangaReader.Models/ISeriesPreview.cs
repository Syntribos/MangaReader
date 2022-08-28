using System;
using System.Collections.Generic;

namespace MangaReader.Models;

public interface ISeriesPreview
{
        Guid Id { get; }

        string Title { get; }

        string PreviewImagePath { get; }

        ISeries ToSeries(HashSet<IChapterPreview> chapterPreviews);
}