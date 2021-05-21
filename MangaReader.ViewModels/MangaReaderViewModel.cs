using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MangaReader.ViewModels
{
    public class MangaReaderViewModel
    {
        public MangaReaderViewModel(string basePath, IEnumerable<string> pages)
        {
            CurrentMangaPage = basePath + pages.First();
        }

        public string CurrentMangaPage { get; private set; }
    }
}