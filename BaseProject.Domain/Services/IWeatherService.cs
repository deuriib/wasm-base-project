using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetWeathersAsync(CancellationToken cancellationToken = default);
}