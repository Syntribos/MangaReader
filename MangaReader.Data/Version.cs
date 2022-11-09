namespace MangaReader.Data;

public class Version
{
    public Version(int major, int minor)
    {
        Major = major;
        Minor = minor;
    }
    
    public int Major { get; }
    
    public int Minor { get; }

    public static Version DefaultVersion => new Version(0, 0);
}