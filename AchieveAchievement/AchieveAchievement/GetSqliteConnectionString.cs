using JBM.DeserializeJson;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievement
{
    public class ConnectionStringSettings
    {
        public static string GetSqliteConnectionString(string dbName, string dbExtension = ".db3", string dbPath = null)
        {
            if (!string.IsNullOrEmpty(dbName) && !string.IsNullOrEmpty(dbExtension))
            {
                if (string.IsNullOrWhiteSpace(dbPath))
                    dbPath = GetDatabasePath();
            }
            else
                throw new ArgumentException("Invalid Database name or Database extension");

            return $"Data Source={Path.Combine(dbPath, (dbName + dbExtension))};";
        }

        public static string GetDatabasePath()
        {
            return FileSystem.AppDataDirectory;
        }

        public static string GetSqliteConnectionStringRawTest()
        {
            string path = GetDatabasePath();
            string connectionString = $"Data Source={Path.Combine(path, ("jbmdb" + ".db3"))};";
            return connectionString;
        }
    }
}
