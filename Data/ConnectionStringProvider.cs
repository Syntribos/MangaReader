using System.Data.SQLite;
using Utilities;

namespace Data;

public class ConnectionStringProvider : IConnectionStringProvider
{
    public ConnectionStringProvider()
    {
        DatabasePath = SqlConstants.DATABASE_PATH;
        ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = DatabasePath, }.ToString();
    }
    
    public string DatabasePath { get; }
    
    public string ConnectionString { get; }
}