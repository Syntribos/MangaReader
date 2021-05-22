using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MangaReader.Models;

namespace MangaReader.ViewModels
{
    public class MangaReaderViewModel
    {
        public MangaReaderViewModel(MangaInfo mangaInfo)
        {
            ChapterInfo = mangaInfo;
        }

        public MangaInfo ChapterInfo { get; }
    }
}