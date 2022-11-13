using System;
using System.Collections.Generic;

namespace Models
{
    public static class SeriesFactory
    {
        public static ISeries EmptySeries => new Series(Guid.Empty, new HashSet<IChapterPreview>(), string.Empty, string.Empty);

        public static ISeries Create(Guid id, HashSet<IChapter> chapters, string title, string previewImagePath)
        {
            return new Series(id, new HashSet<IChapterPreview>(), title, previewImagePath);
        }

        public static ISeries FromDbString(string dbString)
        {
            return EmptySeries;
        }
    }
}