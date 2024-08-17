using BaseProject.Domain.Models;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Weather;

[SkipPersistState]
[FeatureState]
public sealed record WeatherState(bool IsLoading, WeatherForecast[]? Forecasts, string? ErrorMessage)
{
    public WeatherState() : this(false, null, null)
    {
    }
}
