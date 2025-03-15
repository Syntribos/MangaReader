using Utilities;

namespace MangaReader.Cli;

public class VersionProvider : IVersionProvider
{
    public string ProductName => "DesktopMangaReader";

    public string VersionNumber => "alpha-0.0.1";
}
