using System.Net.Http.Json;

namespace WasmBaseProjectApp.Services
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


    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
