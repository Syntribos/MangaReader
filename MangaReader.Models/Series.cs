using System;
using System.Collections.Generic;

namespace MangaReader.Models
{
    public class Series : ISeries
    {
        public Series(HashSet<IChapterPreview> chapters, ISeriesPreview seriesPreview)
        : this(seriesPreview.Id, chapters, seriesPreview.Title, seriesPreview.PreviewImagePath)
        {
        }

        public Series(Guid id, HashSet<IChapterPreview> chapters, string title, string previewImagePath)
        {
            Id = id;
            Chapters = chapters;
            Title = title;
            PreviewImagePath = previewImagePath;
        }

        public Guid Id { get; }
        
        public HashSet<IChapterPreview> Chapters { get; }
        
        public string Title { get; }
        
        public string PreviewImagePath { get; }

        public override string ToString()
        {
            return $"{Title} {Chapters.Count}";
        }
    }
}