using System.Data.SQLite;
using Utilities;

namespace Data;

public class ConnectionStringProvider : IConnectionStringProvider
{
    public ConnectionStringProvider(string path)
    {
        Contract.RequireNotNullOrEmpty(path, nameof(path));

        DatabasePath = path;
        ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = path, }.ToString();
    }
    
    public string DatabasePath { get; }
    
    public string ConnectionString { get; }
}