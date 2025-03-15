using Models;
using Scrapers.Exceptions;
using Scrapers.MangaDex.ApiObjects;

namespace Scrapers.MangaDex;

internal static class MangaDexExtensions
{
    public static IEnumerable<ISeriesPreview> ToSeriesPreviews(this MangaResponse mangaResponse)
    {
        foreach (var manga in mangaResponse.Data?.ToList() ?? Enumerable.Empty<MangaInfo>())
        {
            string title;
            string previewUrl;
            Guid mangaId;
            int chapterCount = 0;

            try
            {
                title = ParseTitle(manga.Attributes);

                MissingRequiredInfoException.ThrowIfNull(manga.Id);
                mangaId = Guid.Parse(manga.Id);

                previewUrl = string.Empty;
            }
            catch (MissingRequiredInfoException)
            {
                // Required info missing for entry
                continue;
            }
            catch (ArgumentNullException)
            {
                continue;
            }
            catch (FormatException)
            {
                // Invalid GUID
                continue;
            }

            yield return new SeriesPreview(
                mangaId,
                title,
                previewUrl,
                chapterCount);
        }
    }

    private static string ParseTitle(MangaAttributes? attributes)
    {
        ArgumentNullException.ThrowIfNull(attributes);

        if (attributes.Title is null)
        {
            MissingRequiredInfoException.ThrowIfNullOrEmpty(attributes.AltTitles, "altTitles");

            if (attributes.AltTitles.FirstOrDefault() is Dictionary<string, string> altTitles)
            {
                if (altTitles.TryGetValue("en", out string? altTitle))
                {
                    return altTitle;
                }

                MissingRequiredInfoException.ThrowIfNullOrEmpty(altTitles);

                return altTitles.First().Value;
            }

            MissingRequiredInfoException.Throw("Title");
        }

        MissingRequiredInfoException.ThrowIfNullOrEmpty(attributes.Title);

        if (attributes.Title.TryGetValue("en", out string? title))
        {
            MissingRequiredInfoException.ThrowIfNullOrEmpty(title);
            return title;
        }
        else if (attributes.Title.Count != 0)
        {
            return attributes.Title.First().Value;
        }

        throw new MissingRequiredInfoException("Title");
    }
}
