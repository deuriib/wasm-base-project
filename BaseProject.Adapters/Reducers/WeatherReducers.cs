using BaseProject.Domain.Models;
using BaseProject.Infrastructure.Store.Weather;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class WeatherReducers
{
    [ReducerMethod]
    public static WeatherState Reduce(WeatherState state, FetchDataAction action)
        => state with
        {
            IsLoading = true,
            Forecasts = Array.Empty<WeatherForecast>(),
            ErrorMessage = string.Empty
        };

    [ReducerMethod]
    public static WeatherState Reduce(WeatherState state, FetchDataSuccessAction action)
        => state with
        {
            IsLoading = false,
            Forecasts = action.Forecasts,
            ErrorMessage = string.Empty
        };

    [ReducerMethod]
    public static WeatherState Reduce(WeatherState state, FetchDataFailAction action)
        => state with
        {
            IsLoading = false,
            Forecasts = Array.Empty<WeatherForecast>(),
            ErrorMessage = action.ErrorMessage
        };
}