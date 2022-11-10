using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using MangaReader.Models;

namespace MangaReader.Data.Implementations;

public class SeriesRepository : ChapterRepository, ISeriesRepository
{
    public SeriesRepository(IConnectionStringProvider connectionStringProvider)
        : base(connectionStringProvider)
    {
    }

    public void SaveManga(ISeries manga)
    {
        const string query = @"
            INSERT INTO []
            ()
            VALUES (@mangaInfo)";

        var parameter = Parameter.CreateParameter("@mangaInfo", manga.ToString());

        ExecuteBooleanNonQuery(query, parameter, (x) => x == 1);
    }

    public IEnumerable<ISeriesPreview> GetAllMangaPreviews(CancellationToken cancellationToken)
    {
        const string query = @"
";
        return ExecuteListReader(query, Enumerable.Empty<Parameter>(), ReadMangaPreviewData, cancellationToken);
    }

    public ISeries BuildSeriesFromPreview(ISeriesPreview preview, CancellationToken cancellationToken)
    {
        const string query = @"
";
        var parameter = Parameter.CreateParameter("@id", preview.Id.ToString());
        var chapterPreviews = ExecuteListReader(query, parameter, ReadChapterData, cancellationToken).ToHashSet();

        return preview.ToSeries(chapterPreviews);
    }

    public IEnumerable<ISeriesPreview> GetMangaPreviewsForCategory(int categoryIndex, CancellationToken cancellationToken)
    {
        const string query = @"
";
        return ExecuteListReader(query, Enumerable.Empty<Parameter>(), ReadMangaPreviewData, cancellationToken);
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
