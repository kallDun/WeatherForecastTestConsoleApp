using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastConsoleApp
{
    public class UserInterface
    {
        public async Task Start()
        {
            Console.WriteLine("1. Display weather forecast from database");
            Console.WriteLine("2. Display weather forecast from API");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            while (true)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await DisplayWeatherForecastFromDatabase();
                        break;
                    case "2":
                        await DisplayWeatherForecastFromAPI();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private async Task DisplayWeatherForecastFromAPI()
        {
            WeatherForecastAPI weatherForecast = new WeatherForecastAPI();
            WeatherForecast data = await weatherForecast.GetWeatherForecast();
            Database database = new Database();
            WeatherForecastDatabaseModel model = DataConverter.ConvertWeatherForecastForDB(data);
            await database.SaveWeatherForecast(model);
            Console.WriteLine(model.ToString());
        }

        private async Task DisplayWeatherForecastFromDatabase()
        {
            Database database = new Database();
            List<WeatherForecastDatabaseModel> weatherForecast = await database.GetWeatherForecast();
            Console.WriteLine(string.Join("\n--------------------------------\n", weatherForecast));
        }
    }
}
