using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MangaReader.Models
{
    public class MangaChapter
    {
        public MangaChapter(string basePath, string[] files)
        {
            Pages = files;
        }
        
        public string[] Pages { get; }
        
        public int PageCount
        {
            get
            {
                return Pages.Length;
            }
        }

        public string GetPagePath(int pageNumber)
        {
            return Pages[pageNumber];
        }
    }
}