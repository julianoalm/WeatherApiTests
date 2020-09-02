using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Weather.IntegrationTests
{
    public class WeatherIntegrationTest
    {
        [Fact]
        [Trait("Teste Integracao", "Juliano")]
        [Description("Teste do método GetAll")]
        public async Task Teste_Integracao_GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000");

                var requisicao = await client.GetAsync($"/api/WeatherForecast/");
                string resposta = await requisicao.Content.ReadAsStringAsync();

                Assert.True(requisicao.IsSuccessStatusCode);
            }
        }

        [Theory(DisplayName = "Retorna o weather por nome")]
        [InlineData("Cool")]
        [InlineData("Freezing")]
        [InlineData("Warm")]
        public async Task Teste_Integracao_GetByName(string Summary)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000");

                var requisicao = await client.GetAsync($"/api/WeatherForecast/GetByName/{Summary}");
                string resposta = await requisicao.Content.ReadAsStringAsync();

                Assert.True(requisicao.IsSuccessStatusCode);
            }
        }
    }
}
