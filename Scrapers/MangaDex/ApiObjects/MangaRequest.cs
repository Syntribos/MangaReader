using Models.Api;
using System.Text.Json.Serialization;
using Utilities;

using Jv = Utilities.JsonValidation;

namespace Scrapers.MangaDex.ApiObjects;

[JsonSerializable(typeof(MangaRequest))]
internal class MangaRequest
{
    [JsonIgnore]
    public static Dictionary<string, Func<object, bool>> OptionalFields = new()
    {
        {
            "Title", Jv.VerifyString(false, 5, 32)
        }
    };

    [JsonIgnore]
    public static Dictionary<string, Func<object, bool>> RequiredFields = [];

    public required Dictionary<string, object> Fields { get; set; }

    public bool Verify()
    {
        foreach (var field in RequiredFields)
        {
            if (!Fields.TryGetValue(field.Key, out var test) || (!field.Value(test)))
            {
                return false;
            }
        }

        return true;
    }
}
