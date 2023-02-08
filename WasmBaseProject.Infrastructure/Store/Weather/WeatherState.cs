using Fluxor.Persist.Storage;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Infrastructure.Store.Weather
{
    [SkipPersistState]
    public record WeatherState(bool IsLoading, WeatherForecast[] Forecasts, string Error);
}
