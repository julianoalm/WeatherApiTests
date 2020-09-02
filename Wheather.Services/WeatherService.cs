using System;
using System.Collections.Generic;
using System.Linq;
using Weather.Model;

namespace Weather.Services
{
    public class WeatherService : IWeatherServices
    {
        public WeatherService()
        {

        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetAll()
        {
            throw new NotImplementedException();
        }

        public WeatherForecast GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
