using System.Text.Json;
using System.Text.Json.Serialization;

namespace Scrapers.MangaDex.ApiObjects;

[JsonSerializable(typeof(MangaAttributes))]
public class MangaAttributes
{
    [JsonPropertyName("title")]
    public Dictionary<string, string>? Title { get; set; }

    [JsonPropertyName("altTitles")]
    public List<Dictionary<string, string>>? AltTitles { get; set; }

    [JsonPropertyName("description")]
    public Dictionary<string, string>? Description { get; set; }

    [JsonPropertyName("isLocked")]
    public bool IsLocked { get; set; }

    [JsonPropertyName("links")]
    public Dictionary<string, string>? Links { get; set; }

    [JsonPropertyName("originalLanguage")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("lastVolume")]
    public string? LastVolume { get; set; }

    [JsonPropertyName("lastChapter")]
    public string? LastChapter { get; set; }

    [JsonPropertyName("publicationDemographic")]
    public string? PublicationDemographic { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("contentRating")]
    public string? ContentRating { get; set; }

    [JsonPropertyName("tags")]
    public List<MangaTag>? Tags { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("chapterNumbersResetOnNewVolume")]
    public bool ChapterNumbersResetOnNewVolume { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("availableTranslatedLanguages")]
    public List<string>? AvailableTranslatedLanguages { get; set; }

    [JsonPropertyName("latestUploadedChapter")]
    public string? LatestUploadedChapter { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Other { get; set; }
}
