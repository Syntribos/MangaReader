using Models.Api;
using System.Text.Json.Serialization;
using Utilities;

using Jv = Utilities.JsonValidation;

namespace Scrapers.MangaDex.ApiObjects;

[JsonSerializable(typeof(MangaRequest))]
internal class MangaRequest
{
    public static Dictionary<string, Func<object, bool>> Fields = new Dictionary<string, Func<object, bool>>()
    {
        {
            "Title", Jv.VerifyString(false, 5, 32)
        }
    };
}
