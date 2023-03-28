using BaseProject.Infrastructure.Store.Auth;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class AuthReducers
{
    [ReducerMethod(typeof(LoginWithEmailAndPasswordActionSuccess))]
    public static AuthState LoginWithEmailAndPasswordAction(AuthState state)
    {
        return new AuthState(isLoading: true, session: null);
    }

    [ReducerMethod]
    public static AuthState LoginWithEmailAndPasswordActionSuccess(
        AuthState state,
        LoginWithEmailAndPasswordActionSuccess action)
    {
        return new AuthState(isLoading: false, session: action.Session);
    }

    [ReducerMethod]
    public static AuthState LoginWithEmailAndPasswordActionFailed(
        AuthState state,
        LoginWithEmailAndPasswordActionFailed action)
    {
        return new AuthState(isLoading: false, session: null);
    }

    [ReducerMethod(typeof(LoginWithGoogleAction))]
    public static AuthState LoginWithGoogleAction(AuthState state)
    {
        return new AuthState(isLoading: true, session: null);
    }

    [ReducerMethod]
    public static AuthState LoginWithGoogleActionSuccess(
        AuthState state,
        LoginWithGoogleActionSuccess action)
    {
        return new AuthState(isLoading: false, session: action.Session);
    }

    [ReducerMethod]
    public static AuthState LoginWithGoogleActionFailed(
        AuthState state,
        LoginWithGoogleActionFailed action)
    {
        return new AuthState(isLoading: false, session: null);
    }
}