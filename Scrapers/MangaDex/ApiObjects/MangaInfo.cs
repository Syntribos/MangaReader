using System.Text.Json.Serialization;

namespace Scrapers.MangaDex.ApiObjects;


[JsonSerializable(typeof(MangaInfo))]
public class MangaInfo
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("attributes")]
    public MangaAttributes? Attributes { get; set; }
}
