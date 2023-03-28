using BaseProject.Infrastructure.Store.Auth;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class AuthReducers
{
    [ReducerMethod(typeof(LoginSuccessAction))]
    public static AuthState LoginWithEmailAndPasswordAction(AuthState state)
    {
        return new AuthState(isLoading: true, session: null);
    }

    [ReducerMethod]
    public static AuthState LoginSuccessAction(
        AuthState state,
        LoginSuccessAction action)
    {
        return new AuthState(isLoading: false, session: action.Session);
    }

    [ReducerMethod]
    public static AuthState LoginFailedAction(
        AuthState state,
        LoginFailedAction action)
    {
        return new AuthState(isLoading: false, session: null);
    }

    [ReducerMethod(typeof(LoginWithGoogleAction))]
    public static AuthState LoginWithGoogleAction(AuthState state)
    {
        return new AuthState(isLoading: true, session: null);
    }
}