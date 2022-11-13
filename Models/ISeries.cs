using System.Collections.Generic;

namespace Models
{
    public interface ISeries
    {
        HashSet<IChapterPreview> Chapters { get; }

        string Title { get; }

        string PreviewImagePath { get; }
    }
}
