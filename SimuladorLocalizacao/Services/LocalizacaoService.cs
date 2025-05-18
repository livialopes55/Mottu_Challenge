using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;

namespace SimuladorLocalizacao.Services
{
    public class LocalizacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly Timer _timer;
        private readonly Random _random = new();

        private readonly int motoId = 1; // ID da moto cadastrada

        public LocalizacaoService()
        {
            _httpClient = new HttpClient();
            _timer = new Timer(10000); // a cada 10 segundos
            _timer.Elapsed += async (s, e) => await EnviarLocalizacaoAsync();
        }

        public void Iniciar() => _timer.Start();

        private async Task EnviarLocalizacaoAsync()
        {
            var localizacao = new
            {
                latitude = -23.5 + _random.NextDouble() * 0.1,
                longitude = -46.6 + _random.NextDouble() * 0.1,
                dataHora = DateTime.Now,
                motoId = motoId
            };

            var json = JsonSerializer.Serialize(localizacao);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://localhost:62621/api/Localizacao", content);
                Console.WriteLine($"Enviado: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar localização: {ex.Message}");
            }
        }
    }
}
