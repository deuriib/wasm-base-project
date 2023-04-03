using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IWeatherService : IService
{
    ValueTask<WeatherForecast[]?> GetWeathersAsync(CancellationToken cancellationToken = default);
}