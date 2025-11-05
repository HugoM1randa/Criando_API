using Microsoft.AspNetCore.Mvc;

namespace MinhaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Teste1")]
        public string GetSaudacoes()
        {
            return $"{DateTime.Now.ToShortDateString()} - Bem Vindo á minha API!";
        }
        [HttpGet("DiaDaSemana")]
        public string Getdia()
        {
            var diaSemana = DateTime.Today.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
            return $"{diaSemana} - Bem Vindo à minha API!";
        }

        [HttpGet("Saudacaopersonalizada")]
        public string GetsaudacaoPersonalizada(string nome)
        {
            return $"Olá {nome}, seja bem vindo!";
        }

        [HttpGet("Dobro")]
        public string Getdobro(int numero)
        {
            return $"O dobro do numero {numero} é {numero * 2}";
        }
        [HttpGet("DataFutura")]
        public string GetdataFutura(int numeroDias)
        {
            var dataFutura = DateTime.Now.AddDays(numeroDias);
            return $"Daqui a {numeroDias} dias será {dataFutura:dd/MM/yyyy}.";
        }
        [HttpGet("TemperaturaFahrenheit")]
        public string GettemperaturaFahrenheit(double Celsius)
        {
            return $"A temperatura em Celsius é de {Celsius} e a em Fahrenheit é de {(Celsius * 9/5) + 32}";
        }

        [HttpGet("CalcularMedia")]
        public string GetcalcularMedia(double a, double b, double c)
        {
            return $"A média dos numeros {a}, {b} e {c} é de {(a + b + c) / 3}";
        }

        [HttpGet("DiaUtil")]
        public string DiaUtil()
        {
            var cultura = new System.Globalization.CultureInfo("pt-BR");
            var diaSemana = DateTime.Today.DayOfWeek;
            var nomeDia = DateTime.Today.ToString("dddd", cultura);

            if (diaSemana >= DayOfWeek.Monday && diaSemana <= DayOfWeek.Friday)
            {
                return $"Hoje é {nomeDia}, um dia útil.";
            }
            else
            {
                return $"Hoje é {nomeDia}, fim de semana.";
            }
        }
    }
}
