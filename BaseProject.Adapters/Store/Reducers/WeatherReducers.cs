using BaseProject.Domain.Models;
using BaseProject.Infrastructure.Store.Weather;
using Fluxor;

namespace BaseProject.Adapters.Store.Reducers
{
    public static class WeatherReducers
    {
        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataAction action)
            => new WeatherState(
                isLoading: true, 
                forecasts: Array.Empty<WeatherForecast>(), 
                errorMessage: string.Empty);

        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataSuccessAction action)
            => new WeatherState(
                isLoading:false, 
                forecasts: action.Forecasts, 
                errorMessage: string.Empty);

        [ReducerMethod]
        public static WeatherState Reduce(WeatherState state, FetchDataFailAction action)
            => new WeatherState(
                isLoading: false, 
                forecasts: Array.Empty<WeatherForecast>(),
                errorMessage: action.ErrorMessage);
    }
}