using Fluxor.Persist.Storage;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Weather
{
    [SkipPersistState]
    public record WeatherState(bool isLoading, WeatherForecast[] forecasts, string error);
}
