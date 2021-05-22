using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MangaReader.Models
{
    public class MangaInfo
    {
        public MangaInfo(string basePath, string[] files)
        {
            BasePath = basePath;
            Pages = files;
        }
        
        public string BasePath { get; }
        
        public string[] Pages { get; }
        
        public int PageCount
        {
            get
            {
                return Pages.Length;
            }
        }
    }
}