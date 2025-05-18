using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SimuladorLocalizacao.Models;

var httpClient = new HttpClient();
var apiUrl = "https://localhost:59071/api/Motos"; 

while (true)
{
    try
    {
        var motos = await httpClient.GetFromJsonAsync<List<Moto>>(apiUrl);
        var ultimaMoto = motos?.OrderByDescending(m => m.Id).FirstOrDefault();

        if (ultimaMoto != null)
        {
            var random = new Random();
            var localizacao = new Localizacao
            {
                MotoId = ultimaMoto.Id,
                Latitude = -23.5 + random.NextDouble() * 0.1,
                Longitude = -46.6 + random.NextDouble() * 0.1,
                DataHora = DateTime.Now
            };

            var response = await httpClient.PostAsJsonAsync("https://localhost:59071/api/Localizacao", localizacao);

            if (response.IsSuccessStatusCode)
            {
                
            }
        }
    }
    catch (Exception ex)
    {
        
    }

    await Task.Delay(10000); 
}
