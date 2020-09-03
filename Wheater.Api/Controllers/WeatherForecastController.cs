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
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
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

        [HttpGet("GetByName/{Name}")]
        public ActionResult Get(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                WeatherForecast result = _weatherServices.GetByName(Name);
                
                return Ok(result);
            }
            else
            {
                return BadRequest("O parâmetro nome não pode ser nulo");
            }
        }
    }
}
