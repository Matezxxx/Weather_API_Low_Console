using Newtonsoft.Json;

namespace Weather_API
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            string goOn;
            do
            {
                Console.WriteLine("Welcome to the Weather App!");
                Console.WriteLine("Enter the name of a city:");

                string city = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(city))
                {
                    Console.WriteLine("City name cannot be empty. Exiting...");
                    return;
                }

                try
                {
                    // get the data about weather
                    string apiKey = "7985f658b544ad536a6559be42f3310d"; // Here insert your API key
                    string weatherData = await GetWeatherDataAsync(city, apiKey);

                    // Display data
                    DisplayWeather(weatherData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                Console.WriteLine();
                Console.WriteLine("If you want to choose another city, type \"y\" and hit the enter. Otherwise hit any keyword twice to exit the app."); 
                goOn = Console.ReadLine();
                Console.WriteLine();
            }while (goOn=="y");
        }

        static async Task<string> GetWeatherDataAsync(string city, string apiKey)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error: {response.StatusCode}\n{errorContent}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        static void DisplayWeather(string json)
        {
            // JSON deserialization answer
            var weather = JsonConvert.DeserializeObject<WeatherResponse>(json);

            Console.WriteLine("\nWeather Information:");
            Console.WriteLine($"City: {weather.Name}");
            Console.WriteLine($"Temperature: {weather.Main.Temp} °C");
            Console.WriteLine($"Humidity: {weather.Main.Humidity}%");
            Console.WriteLine($"Wind Speed: {weather.Wind.Speed} m/s");
        }
    }




}

