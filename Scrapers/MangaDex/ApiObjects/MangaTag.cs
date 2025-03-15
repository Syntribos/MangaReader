using System.Text.Json.Serialization;

namespace Scrapers.MangaDex.ApiObjects;

public class MangaTag
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("attributes")]
    public TagAttributes? Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public List<Relationship>? Relationships { get; set; }
}

public class TagAttributes
{
    [JsonPropertyName("name")]
    public Dictionary<string, string>? Name { get; set; }

    [JsonPropertyName("description")]
    public Dictionary<string, string>? Description { get; set; }

    [JsonPropertyName("group")]
    public string? Group { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }
}

public class Relationship
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
