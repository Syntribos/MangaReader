using Models.Api;

namespace Scrapers.MangaDex;

internal static class ApiConstants
{
    internal const string API_URL = @"https://api.mangadex.org";
    internal const string MANGA_URL = $"{API_URL}/manga";
    internal const string CHAPTER_URL = $"{API_URL}/chapter";
    internal const string LIST_URL = $"{API_URL}/list";

    internal const string CHAPTER = "chapter";
    internal const string MANGA = "manga";
    internal const string COVER_ART = "cover_art";
    internal const string SCANLATION_GROUP = "scanlation_group";
    internal const string USER = "user";
    internal const string AUTHOR = "author";
    internal const string ARTIST = "artist";
    internal const string TAG = "tag";
    internal const string LIST = "custom_list";
    internal const string LEGACY_NO_GROUP_ID = "00e03853-1b96-4f41-9542-c71b8692033b";

    internal static readonly List<(string ReadableName, string ApiLabel)> SORTABLE_FIELDS
        = new List<(string ReadableName, string ApiLabel)>()
        {
            ("Latest Chapter", "latestUploadedChapter"),
        };
}
