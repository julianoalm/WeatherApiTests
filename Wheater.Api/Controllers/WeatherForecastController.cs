using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Model;
using Weather.Services;

namespace Wheater.Api.Controllers
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
        private readonly IWeatherServices _weatherServices;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherServices weatherServices)
        {
            _logger = logger;
            _weatherServices = weatherServices;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherServices.GetAll();
        }
    }
}
