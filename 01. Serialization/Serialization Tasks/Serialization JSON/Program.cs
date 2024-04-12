using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serialization_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WeatherForecast weatherForecast = new WeatherForecast()
            //{
            //    Date = DateTime.Now,
            //    TemperatureC = 35,
            //    Summary="It is a hot day"
            //};

            //string weatherForecastJson=JsonSerializer.Serialize(weatherForecast);

            //Console.WriteLine(weatherForecastJson);

            //string jsonString = File.ReadAllText("C:\\Users\\Admin\\Desktop\\Back End" +
            //    " Automation\\Serialization Tasks\\Serialization JSON\\Weather.json");

            //string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory + "/../../../Weather.json"));

            //var weatherObject=JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);

            //Console.WriteLine(weatherObject); 


            //WeatherForecast weatherForecast = new WeatherForecast()
            //   {
            //       Date = DateTime.Now,
            //       TemperatureC = 35,
            //       Summary = "It is rainy day"
            //   };

            //   string jsonSerialize=JsonConvert.SerializeObject(weatherForecast, Formatting.Indented); 
            //   Console.WriteLine(jsonSerialize);

            //string jsonObject = File.ReadAllText(Path.Combine(Environment.CurrentDirectory + "/../../../People.json"));

            //var peopleObect = new
            //{
            //    FirstName = string.Empty,
            //    LastName = string.Empty,
            //    JobTitle = string.Empty
            //};

            //var peopleJson = JsonConvert.DeserializeAnonymousType(jsonObject, peopleObect); 

            string jsonObject = File.ReadAllText(Path.Combine(Environment.CurrentDirectory + "/../../../Weather.json"));

            var jsonWeather = JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonObject);

            //LinQ to Json 

            string json = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../People.json");

            var person = JObject.Parse(json);

            Console.WriteLine(person.ToString());
            Console.WriteLine(person["firstName"]);
            Console.WriteLine(person["lastName"]);

            var json1 = JObject.Parse(@"{'products':[{'name':'Fruits', 'products':['apple', 'banana']}, " +
                "'name': 'Vegetables', 'products':['cucumber']}]}");
            var products = json1["products"].Select(t => string.Format("{0} ({1})", t["name"], string.Join(",", t["products"])));
        }
    }
}
