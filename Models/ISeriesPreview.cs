using System;
using System.Collections.Generic;

namespace Models;

public interface ISeriesPreview
{
        Guid Id { get; }

        string Title { get; }

        string PreviewImagePath { get; }

        ISeries ToSeries(HashSet<IChapterPreview> chapterPreviews);
}