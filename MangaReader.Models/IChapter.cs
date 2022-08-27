using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaReader.Models
{
    public interface IChapter
    {
        string[] PageFilenames { get; }

        int PageCount { get; }
        
        string PreviewImagePath { get; }

        string GetPagePath(int pageNumber);
    }
}