using System.Collections.Generic;

namespace MangaReader.Models
{
    public class Manga
    {
        public Manga()
        {
            
        }
        
        public HashSet<MangaChapter> Chapters { get; }
        
        public string Title { get; }
        
        public string PreviewImagePath { get; }
    }
}