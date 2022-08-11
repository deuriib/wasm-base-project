using Fluxor;

namespace WasmBaseProject.Infrastructure.Store.Theme
{
    public static class Reducers
    {
        [ReducerMethod]
        public static ThemeState Reduce(ThemeState state, ToggleThemeAction action) =>
            new ThemeState(IsDarkMode: !state.IsDarkMode);
    }
}