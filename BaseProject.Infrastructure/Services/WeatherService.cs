using System.Net.Http.Json;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;

namespace BaseProject.Infrastructure.Services
{
    public sealed class WeatherService(HttpClient httpClient) : IWeatherService
    {
        public async ValueTask<WeatherForecast[]?> GetWeathersAsync(CancellationToken cancellationToken = default)
        {
            return await httpClient
                .GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json",
                cancellationToken: cancellationToken);
        }
    }
}