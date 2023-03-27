﻿using BaseProject.Infrastructure.Store.Theme;
using Fluxor;

namespace BaseProject.Adapters.Store.Reducers
{
    public static class ThemeReducers
    {
        [ReducerMethod]
        public static ThemeState Reduce(ThemeState state, ToggleThemeAction action) =>
            new ThemeState(isDarkMode: !state.IsDarkMode);
    }
}