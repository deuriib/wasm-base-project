using System.Net.Http.Json;
using BaseProject.Domain.Models;

namespace BaseProject.Adapters.Services
{
    public class WeatherService
    {
        private readonly HttpClient _http;
        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WeatherForecast[]> GetWeathersAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            
            return (await _http
                .GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json",
                cancellationToken: cancellationToken))!;
        }
    }
}