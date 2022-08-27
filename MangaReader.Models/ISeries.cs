using System.Collections.Generic;

namespace MangaReader.Models
{
    public interface ISeries
    {
        HashSet<IChapterPreview> Chapters { get; }

        string Title { get; }

        string PreviewImagePath { get; }

        string AsDatabaseString();
    }
}
