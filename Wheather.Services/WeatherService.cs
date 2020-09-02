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
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public WeatherForecast GetByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray().Where(x => x.Summary == name).FirstOrDefault();
            }
            else
            {
                throw new Exception("O parâmetro nome não pode ser nulo");
            }
        }
    }
}
