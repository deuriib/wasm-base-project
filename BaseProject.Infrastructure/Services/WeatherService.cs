using System.Net.Http.Json;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;

namespace BaseProject.Infrastructure.Services
{
    public sealed class WeatherService : IWeatherService
    {
        private readonly HttpClient _http;
        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        public async ValueTask<WeatherForecast[]?> GetWeathersAsync(CancellationToken cancellationToken = default)
        {
            return await _http
                .GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json",
                cancellationToken: cancellationToken);
        }
    }
}