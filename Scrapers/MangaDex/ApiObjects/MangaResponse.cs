using System.Text.Json;
using System.Text.Json.Serialization;

namespace Scrapers.MangaDex.ApiObjects;

[JsonSerializable(typeof(MangaResponse))]
public class MangaResponse
{
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    [JsonPropertyName("response")]
    public string? Response { get; set; }

    [JsonPropertyName("data")]
    public List<MangaInfo>? Data { get; set; }
}
