using System.Collections.Generic;

namespace MangaReader.Models
{
    public class Series : ISeries
    {
        public Series(HashSet<IChapter> chapters, string title, string previewImagePath)
        {
            Chapters = chapters;
            Title = title;
            PreviewImagePath = previewImagePath;
        }
        
        public HashSet<IChapter> Chapters { get; }
        
        public string Title { get; }
        
        public string PreviewImagePath { get; }

        public string AsDatabaseString()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return $"{Title} {Chapters.Count}";
        }
    }
}