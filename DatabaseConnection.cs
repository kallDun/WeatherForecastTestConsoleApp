using System;
using System.Data.SQLite;

namespace WeatherForecastConsoleApp
{
    public static class DatabaseConnection
    {
        private static SQLiteConnection _instance;

        public static SQLiteConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = CreateConnection();
                CreateTable(_instance);
            }
            return _instance;
        }

        private static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return sqlite_conn;
        }

        private static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE IF NOT EXISTS WeatherForecast " +
                "(city text, date text, temperature numeric(3,2), " +
                "feels_like numeric(3,2), pressure numeric(3,2), humidity numeric(3,2))";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
