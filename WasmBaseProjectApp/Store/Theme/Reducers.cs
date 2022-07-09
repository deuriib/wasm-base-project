using Fluxor;

namespace WasmBaseProjectApp.Store.Theme
{
    public static class Reducers
    {
        [ReducerMethod]
        public static ThemeState Reduce(ThemeState state, ToggleThemeAction action)
        {
            return state with { isDarkMode = !state.isDarkMode };
        }
    }
}
