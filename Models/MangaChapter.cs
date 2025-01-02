using System;
using System.IO;
using System.Linq;

namespace Models
{
    public class MangaChapter : IChapter
    {
        private readonly string _basePath;

        public MangaChapter(string chapterName, int chapterNumber, string basePath, string[] fileNames, string previewFilename)
        {
            _basePath = basePath;

            ChapterName = chapterName;
            ChapterNumber = chapterNumber;
            PageFilenames = fileNames;
            PreviewImagePath = Path.Combine(_basePath, previewFilename);
        }

        public MangaChapter(string chapterName, int chapterNumber, string basePath, string[] fileNames)
        : this(chapterName, chapterNumber, basePath, fileNames, Path.Combine(basePath, fileNames.FirstOrDefault()))
        {
        }
        
        public string ChapterName { get; }
        
        public int ChapterNumber { get; }
        
        public string[] PageFilenames { get; }

        public int PageCount => PageFilenames.Length;

        public string PreviewImagePath { get; }

        public string GetPagePath(int pageNumber)
        {
            return Path.Combine(_basePath, PageFilenames[Math.Clamp(pageNumber, 0, PageCount - 1)]);
        }
    }
}