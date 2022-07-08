using Fluxor.Persist.Storage;
using MudCounter.Services;

namespace MudCounter.Store.Weather
{
    [SkipPersistState]
    public record WeatherState(bool isLoading, WeatherForecast[] forecasts, string error);
}
