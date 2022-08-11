using Fluxor;
using WasmBaseProject.Adapters.Services;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Infrastructure.Store.Weather
{
    public static class WeatherReducers
    {
        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataAction action)
            => state with { IsLoading = true, Forecasts = Array.Empty<WeatherForecast>(), Error = string.Empty };

        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataSuccessAction action)
            => state with { IsLoading = false, Forecasts = action.Forecasts, Error = string.Empty };

        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataFailAction action)
           => state with { IsLoading = false, Forecasts = Array.Empty<WeatherForecast>(), Error = action.ErrorMessage };
    }
}
