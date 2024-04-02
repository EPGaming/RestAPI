using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        internal static List<Students> students = new List<Students>();

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Getalt()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        //Api ist schnittstelle zwischen Client und Server
        //Wir definieren nur die Schnittstelle hier
        //Client ist zb Whatsapp -> Cache ist lokaler zwischenspeicher für temporäre Daten (Musik auf Spotify)
        //Man fordert kleine Pakete über request vom Server an und bekommt sie dann durch response
        //Auf dem Server liegt schnittstelle (API) welche uns zugriff auf den Server gibt
        //HTTP ist ein Protokoll für die Kommunikation im Web
        //Protokoll ist eine Vorgehensweise für die Kommunikation zwischen Parteien (Ablauf von Kommunikationsschritte)
        //HTTP legt daher standartbefehle, 4 wichtige Befehle (Get, Post, Put, Delete)
        //Post -> ich lege neue Daten an, erstellt Ressourcen und kann aber eigentlich alles machen (Response)
        //Get -> heißt gib mir etwas, Rückmeldung (Request)
        //Put -> Updaten

        [HttpPost]
        public IActionResult Post(int id, string name) //IActionReslut -> will Statuscode zurück (404 -> Ressource fehlt, 500 -> interner Servererror... fehler beim Programmieren oder so)
        {
            students.Add(new Students(id, name)); //Students ist static -> beim starten werden die static variablen in unsern ram gelegt also kann ich immer darauf zugreifen wenn es läuft
            StreamWriter sw = new StreamWriter(@"H:\\SWP\\RestAPI\\RestAPI\\RestAPI\\text.txt");
            foreach (var student in students)
            {
                sw.WriteLine(student);
            }
            sw.Close();
                        
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Students> Get()
        {
            StreamReader sr = new StreamReader(@"H:\\SWP\\RestAPI\\RestAPI\\RestAPI\\text.txt");
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        
            return students;
        }

        [HttpPut]
        public IActionResult Put(int id,string name)
        {

            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].ID == id)
                {
                    students[i].Name = name;
                }
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].ID == id)
                {
                    students.RemoveAt(i);
                }
            }
            return Ok();
        }
    }
}