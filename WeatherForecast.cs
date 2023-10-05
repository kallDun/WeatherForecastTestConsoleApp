namespace WeatherForecastConsoleApp
{
    public class WeatherForecastDatabaseModel
    {
        public string City { get; set; }
        public string Date { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }

        public override string ToString()
        {
            return $"City: {City}\nDate: {Date}\nTemperature: {Temperature}\nFeels like: {FeelsLike}\nPressure: {Pressure}\nHumidity: {Humidity}";
        }
    }

    public class WeatherForecast
    {
        public string cod { get; set; }
        public string message { get; set; }
        public int cnt { get; set; }
        public WeatherForecastData[] list { get; set; }
        public City city { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class WeatherForecastData
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public double humidity { get; set; }
        public double temp_kf { get; set; }
    }
}