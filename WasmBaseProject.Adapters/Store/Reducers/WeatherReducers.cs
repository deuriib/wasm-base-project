using Fluxor;
using WasmBaseProject.Adapters.Services;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Infrastructure.Store.Weather
{
    public static class WeatherReducers
    {
        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataAction action)
            => state with { isLoading = true, forecasts = Array.Empty<WeatherForecast>(), error = string.Empty };

        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataSuccessAction action)
            => state with { isLoading = false, forecasts = action.Forecasts, error = string.Empty };

        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataFailAction action)
           => state with { isLoading = false, forecasts = Array.Empty<WeatherForecast>(), error = action.ErrorMessage };
    }
}
