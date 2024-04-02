using Microsoft.AspNetCore.Mvc;

namespace RestApi5CMaturaVorbereitung.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        internal static Dictionary<int,string> students=new Dictionary<int,string>();
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //[HttpPost(Name ="PostTemperature")]
        //public IActionResult Post(WeatherForecast forecast)
        //{
        //    if (forecast!=null)
        //    {
        //        Console.WriteLine(forecast.TemperatureC);
        //        Console.WriteLine(forecast.Summary);
        //    }
        //    return Ok(forecast);
        //}

        [HttpPost]
        public IActionResult PostStandard(int id, string name)
        {
            students.Add(id, name);



            return Ok();
        }


        [HttpPut]
        public IActionResult Put(int id, string name, WeatherForecast forecast)
        {
            Console.WriteLine(id);
            Console.WriteLine(name);
            StreamWriter sw = new StreamWriter("myfile.txt");

            sw.WriteLine(id);
            sw.WriteLine(name);
            sw.Close();
            return Ok(forecast);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }
}
