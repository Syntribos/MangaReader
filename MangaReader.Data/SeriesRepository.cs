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

            var parameter = CreateParam("@mangaInfo", manga.ToString());

            ExecuteBooleanNonQuery(query, parameter, (x) => x == 1);
        }

        public IEnumerable<ISeriesPreview> GetAllMangaPreviews()
        {
            const string query = @"
";
            yield return ExecuteReader(query, Enumerable.Empty<(string, string)>(), ReadMangaPreviewData);
        }

        public ISeries BuildSeriesFromPreview(ISeriesPreview preview)
        {
            const string query = @"
";
            var parameter = CreateParam("@id", preview.Id.ToString());
            var chapterPreviews = ExecuteListReader(query, parameter, ReadChapterData).ToHashSet();

            return preview.ToSeries(chapterPreviews);
        }

        public IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex)
        {
            const string query = @"
";
            return ExecuteListReader(query, Enumerable.Empty<(string, string)>(), ReadMangaPreviewData);
        }

        private static ISeriesPreview ReadMangaPreviewData(IDataReader reader)
        {
            var seriesId = reader.GetGuid(reader.GetOrdinal("series_id"));
            var seriesTitle = reader.GetString(reader.GetOrdinal("series_title"));
            var basePath = reader.GetString(reader.GetOrdinal("series_path"));
            var previewFilename = reader.GetString(reader.GetOrdinal("series_preview_filename"));
            var chapterCount = reader.GetInt32(reader.GetOrdinal("series_chapter_count"));
            var unreadChapterCount = reader.GetInt32(reader.GetOrdinal("series_undread_chapter_count"));

            return new SeriesPreview(seriesId, seriesTitle, Path.Combine(basePath, previewFilename), chapterCount, unreadChapterCount);
        }

        private static IChapterPreview ReadChapterData(IDataReader reader)
        {
            return new MangaChapterPreview(string.Empty, 0, 0, string.Empty, string.Empty);
        }
    }
}