using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherClass forecast = new WeatherClass()
            {
                Date = DateTime.Now,
                TemperatureC = 32,
                Summary = "New Random Test"
            };

            //    string forecastsJson=JsonSerializer.Serialize(forecasts);
            //    Console.WriteLine(forecastsJson);
            //}
            //string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory)+ "/../../../Weather.json");
            //var jsonDecerialed=JsonSerializer.Deserialize<List<WeatherClass>>(jsonString);
            //foreach (var weather in jsonDecerialed)
            //{
            //    Console.WriteLine(weather);
            //}

            //string path = Path.Combine(Environment.CurrentDirectory, "../../../Weather.json");
            //string jsonString = File.ReadAllText(path);
            //var jsonDeserialized = JsonSerializer.Deserialize<List<WeatherClass>>(jsonString);

            //foreach (var weather in jsonDeserialized)
            //{
            //    Console.WriteLine(weather.Summary);
            //}

            //string forecastJson = JsonConvert.SerializeObject(forecast,Formating.Intended);
            //Console.WriteLine(forecastJson);

            string stringJson1 = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../People.json");
            Console.WriteLine(stringJson1);

            var person = new
            {
                FirstName = string.Empty,
                SecondName = string.Empty,
                JobTitle = string.Empty

            };

            var watherForecastObject = JsonConvert.DeserializeAnonymousType(stringJson1, person);

            string stringJson2 = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../People.json");

            var person1=JsonObject.Parse(stringJson2);
            Console.WriteLine(person1["firstName"]);
            Console.WriteLine(person1["secondName"]);

            //var json=JsonObject.Parse($"{"products":"
            //   + ["name":"Fruits", 
            //    "" +
            //    ""{

            //}
            //   ]
            //    ")
            

        }
    }
}
