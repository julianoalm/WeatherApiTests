using System;
using System.ComponentModel;
using Xunit;
using Weather.Model;
using Weather.Services;
using System.Collections.Generic;
using Moq;

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
        [Description("Teste do método GetAll")]
        public void Testa_GetAll_Valida_Quantidade()
        {
            _weather = new WeatherService();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            Assert.True(result.Count == Summaries.Length);
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do método GetAll")]
        public void Testa_GetAll_Valida_Tipo()
        {
            _weather = new WeatherService();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());
            
            Assert.IsType<WeatherForecast>(result[0]);            
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do método GetAll")]
        public void Testa_GetAll_Valida_Retorno()
        {
            _weather = new WeatherService();
            WeatherForecast model = new WeatherForecast();
            
            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            model = result[0];

            Assert.Contains(model, result);
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste utilizando Moq devido ao metodo GetByName não estar pronto")]
        public void Testa_GetByName_Moq()
        {
            var weather = new Mock<IWeatherServices>(MockBehavior.Strict);
            
            WeatherForecast model = new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = "Cool",
                TemperatureC = 20
            };

            weather.Setup(w => w.GetByName(It.IsAny<string>())).Returns(() => model);

            Assert.Equal<WeatherForecast>(model, weather.Object.GetByName("Cool"));
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste passando um nome vazio")]
        public void Testa_GetByName_Name_Null()
        {
            var weather = new WeatherService();

            Exception ex = Assert.Throws<Exception>(() => weather.GetByName(""));

            Assert.Equal("O parâmetro nome não pode ser nulo", ex.Message);
        }
    }
}
