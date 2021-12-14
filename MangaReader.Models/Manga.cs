using System.Collections.Generic;

namespace MangaReader.Models
{
    public class Manga : ISeries
    {
        public Manga()
        {
            
        }
        
        public HashSet<IChapter> Chapters { get; }
        
        public string Title { get; }
        
        public string PreviewImagePath { get; }

        public string AsDatabaseString()
        {
            return string.Empty;
        }
    }
}