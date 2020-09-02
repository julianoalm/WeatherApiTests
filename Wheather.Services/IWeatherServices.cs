using System;
using System.Collections.Generic;
using System.Text;
using Weather.Model;

namespace Weather.Services
{
    public interface IWeatherServices
    {
        IEnumerable<WeatherForecast> GetAll();
        WeatherForecast GetByName(string name);
    }
}
