namespace Utilities;

public interface IVersionProvider
{
    string ProductName { get; }
    string VersionNumber { get; }
}
