using System.Threading.Tasks;

namespace WeatherForecastConsoleApp
{
    public class Program
    {
        static async Task Main()
        {
            UserInterface userInterface = new UserInterface();
            await userInterface.Start();
        }
    }
}
