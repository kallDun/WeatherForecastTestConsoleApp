namespace WeatherForecastConsoleApp
{
    public static class DataConverter
    {
        public static WeatherForecastDatabaseModel ConvertWeatherForecastForDB(WeatherForecast weatherForecast)
        {
            WeatherForecastDatabaseModel weatherForecastDatabaseModel = new WeatherForecastDatabaseModel();
            weatherForecastDatabaseModel.City = weatherForecast.city.name;
            weatherForecastDatabaseModel.Date = weatherForecast.list[0].dt_txt;
            weatherForecastDatabaseModel.Temperature = weatherForecast.list[0].main.temp;
            weatherForecastDatabaseModel.FeelsLike = weatherForecast.list[0].main.feels_like;
            weatherForecastDatabaseModel.Pressure = weatherForecast.list[0].main.pressure;
            weatherForecastDatabaseModel.Humidity = weatherForecast.list[0].main.humidity;
            return weatherForecastDatabaseModel;
        }
    }
}
