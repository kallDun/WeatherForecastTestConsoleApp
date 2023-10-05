using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace WeatherForecastConsoleApp
{
    public class Database
    {
        
        public async Task SaveWeatherForecast(WeatherForecastDatabaseModel data)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(DatabaseConnection.GetInstance()))
            {
                cmd.CommandText = "INSERT INTO WeatherForecast (city, date, temperature, feels_like, pressure, humidity) " +
                    "VALUES (@city, @date, @temperature, @feels_like, @pressure, @humidity)";
                cmd.Parameters.AddWithValue("@city", data.City);
                cmd.Parameters.AddWithValue("@date", data.Date);
                cmd.Parameters.AddWithValue("@temperature", data.Temperature);
                cmd.Parameters.AddWithValue("@feels_like", data.FeelsLike);
                cmd.Parameters.AddWithValue("@pressure", data.Pressure);
                cmd.Parameters.AddWithValue("@humidity", data.Humidity);
                cmd.Prepare();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<WeatherForecastDatabaseModel>> GetWeatherForecast()
        {
            List<WeatherForecastDatabaseModel> weatherForecast = new List<WeatherForecastDatabaseModel>();
            using (SQLiteCommand cmd = new SQLiteCommand(DatabaseConnection.GetInstance()))
            {
                cmd.CommandText = "SELECT * FROM WeatherForecast";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        weatherForecast.Add(new WeatherForecastDatabaseModel
                        {
                            City = reader.GetString(0),
                            Date = reader.GetString(1),
                            Temperature = reader.GetFloat(2),
                            FeelsLike = reader.GetFloat(3),
                            Pressure = reader.GetFloat(4),
                            Humidity = reader.GetFloat(5)
                        });
                    }
                }
            }
            return weatherForecast;
        }
    }
}
