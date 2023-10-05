using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecastConsoleApp
{
    public class WeatherForecastAPI
    {
        private class ForecastAPIData
        {
            [JsonProperty("api_key")]
            public string ApiKey { get; set; }
        }

        public async Task<WeatherForecast> GetWeatherForecast()
        {
            ForecastAPIData data = GetApiDataFromFile();
            double lat = 49.441937;
            double lon = 32.063456;
            string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={data.ApiKey}&units=metric";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherForecast>(json);
        }

        private ForecastAPIData GetApiDataFromFile()
        {
            string file = File.ReadAllText("appconfig.json");
            return JsonConvert.DeserializeObject<ForecastAPIData>(file);
        }
    }
}