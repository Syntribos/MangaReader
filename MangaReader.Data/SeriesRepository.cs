using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using MangaReader.Data.Interfaces;
using MangaReader.Models;

namespace MangaReader.Data
{
    public class SeriesRepository : ChapterRepository, ISeriesRepository
    {
        public SeriesRepository(string databasePath)
            : base(databasePath)
        {
        }

        public void SaveManga(ISeries manga)
        {
            const string query = @"
                INSERT INTO []
                ()
                VALUES (@mangaInfo)";

            var parameter = CreateParam("@mangaInfo", manga.AsDatabaseString());

            ExecuteBooleanNonQuery(query, parameter, (x) => x == 1);
        }

        public IEnumerable<ISeriesPreview> GetAllMangaPreviews()
        {
            const string query = @"
";
            yield return ExecuteReader(query, Enumerable.Empty<(string, string)>(), ReadMangaPreviewData);
        }

        public IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex)
        {
            const string query = @"
";
            return ExecuteListReader(query, Enumerable.Empty<(string, string)>(), ReadMangaPreviewData);
        }

        private ISeriesPreview ReadMangaPreviewData(IDataReader reader)
        {
            var seriesTitle = reader.GetString(reader.GetOrdinal("series_title"));
            var basePath = reader.GetString(reader.GetOrdinal("series_path"));
            var previewFilename = reader.GetString(reader.GetOrdinal("series_preview_filename"));
            var chapterCount = reader.GetInt32(reader.GetOrdinal("series_chapter_count"));
            var unreadChapterCount = reader.GetInt32(reader.GetOrdinal("series_undread_chapter_count"));

            return new SeriesPreview(seriesTitle, Path.Combine(basePath, previewFilename), chapterCount, unreadChapterCount);
        }
    }
}