using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IWeatherService
{
    ValueTask<WeatherForecast[]?> GetWeathersAsync(CancellationToken cancellationToken = default);
}