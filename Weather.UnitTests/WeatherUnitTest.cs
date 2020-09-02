using System;
using System.ComponentModel;
using Xunit;
using Weather.Model;
using Weather.Services;
using System.Collections.Generic;

namespace Weather.UnitTests
{
    public class WeatherUnitTest
    {
        private IWeatherServices _weather;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do m�todo GetAll")]
        public void Testa_GetAll_Valida_Quantidade()
        {
            _weather = new WeatherService();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            Assert.True(result.Count == Summaries.Length);
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do m�todo GetAll")]
        public void Testa_GetAll_Valida_Tipo()
        {
            _weather = new WeatherService();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());
            
            Assert.IsType<WeatherForecast>(result[0]);            
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do m�todo GetAll")]
        public void Testa_GetAll_Valida_Retorno()
        {
            _weather = new WeatherService();
            WeatherForecast model = new WeatherForecast();
            
            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            model = result[0];

            Assert.Contains(model, result);
        }
    }
}