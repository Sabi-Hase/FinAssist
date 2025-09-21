
using Microsoft.Data.Sqlite;
using System.IO;

namespace FinAssist.Data
{
    public static class SQLiteContext
    {
        private static string dbPath = "FinAssist.db";

        public static SqliteConnection GetConnection()
        {
            if (!File.Exists(dbPath))
            {
                using (var conn = new SqliteConnection($"Data Source={dbPath}"))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Usuarios(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT,
                        Gastos REAL
                    );";
                    cmd.ExecuteNonQuery();
                }
            }
            return new SqliteConnection($"Data Source={dbPath}");
        }
    }
}
