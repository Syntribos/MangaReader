using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaReader.Models
{
    public static class SeriesFactory
    {
        public static ISeries EmptySeries => new Series(new HashSet<IChapterPreview>(), string.Empty, String.Empty);

        public static ISeries Create(HashSet<IChapter> chapters, string title, string previewImagePath)
        {
            return new Series(new HashSet<IChapterPreview>(), title, previewImagePath);
        }

        public static ISeries FromDbString(string dbString)
        {
            return EmptySeries;
        }
    }
}