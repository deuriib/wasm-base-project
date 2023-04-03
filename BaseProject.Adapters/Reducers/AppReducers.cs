using BaseProject.Infrastructure.Store.App;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class AppReducers
{
    [ReducerMethod(typeof(ToggleLeftMenuAction))]
    public static AppState OnToggleLeftMenuAction(AppState state) =>
        state with
        {
            IsLeftMenuOpen = !state.IsLeftMenuOpen
        };
}