using System.Net.Http.Json;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Adapters.Services
{
    public class WeatherService
    {
        private readonly HttpClient _http;

        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WeatherForecast[]> GetWeathersAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return (await _http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json"))!;
        }
    }
}
