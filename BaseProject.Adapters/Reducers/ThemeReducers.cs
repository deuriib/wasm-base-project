using BaseProject.Infrastructure.Store.Theme;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class ThemeReducers
{
    [ReducerMethod(typeof(ToggleThemeAction))]
    public static ThemeState OnToggleThemeAction(ThemeState state) =>
        state with { IsDarkMode = !state.IsDarkMode };
}