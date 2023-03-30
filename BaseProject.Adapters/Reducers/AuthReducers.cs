using BaseProject.Infrastructure.Store.Auth;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class AuthReducers
{
    [ReducerMethod(typeof(LoginWithEmailAndPasswordAction))]
    public static AuthState LoginWithEmailAndPassword(AuthState state) 
        => new (isLoading: true, session: null);

    [ReducerMethod]
    public static AuthState LoginSuccess(
        AuthState state,
        LoginSuccessAction action) =>
        new (isLoading: false, session: action.Session);

    [ReducerMethod]
    public static AuthState LoginFailed(
        AuthState state,
        LoginFailedAction action)
    {
        return new AuthState(isLoading: false, session: null);
    }

    [ReducerMethod(typeof(LoginWithGoogleAction))]
    public static AuthState LoginWithGoogle(AuthState state)
    {
        return new AuthState(isLoading: true, session: null);
    }
}