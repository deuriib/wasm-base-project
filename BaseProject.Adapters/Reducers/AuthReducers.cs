using BaseProject.Infrastructure.Store.Auth;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class AuthReducers
{
    [ReducerMethod(typeof(LoginWithEmailAndPasswordAction))]
    public static AuthState OnLoginWithEmailAndPasswordAction(AuthState state)
        => state with
        {
            IsLoading = true,
            Session = null
        };

    [ReducerMethod]
    public static AuthState OnLoginSuccessAction(
        AuthState state,
        LoginSuccessAction action) =>
        state with
        {
            IsLoading = false,
            Session = action.Session
        };

    [ReducerMethod]
    public static AuthState OnLoginFailAction(
        AuthState state,
        LoginFailedAction action)
        => state with
        {
            IsLoading = false,
            Session = null,
            ErrorMessage = action.ErrorMessage
        };

    [ReducerMethod(typeof(LoginWithGoogleAction))]
    public static AuthState LoginWithGoogle(AuthState state)
        => state with
        {
            IsLoading = true,
            Session = null
        };
    
    [ReducerMethod(typeof(ForgotPasswordAction))]
    public static AuthState OnForgotPasswordAction(
        AuthState state) =>
        state with
        {
            IsLoading = true,
            IsEmailForgotPasswordSent = false
        };
    
    [ReducerMethod(typeof(ForgotPasswordResetAction))]
    public static AuthState OnForgotPasswordResetAction(
        AuthState state) =>
        state with
        {
            IsLoading = false,
            IsEmailForgotPasswordSent = false
        };
    
    [ReducerMethod(typeof(ForgotPasswordSuccessAction))]
    public static AuthState OnForgotPasswordSuccessAction(
        AuthState state) =>
        state with
        {
            IsLoading = false,
            IsEmailForgotPasswordSent = true
        };
    
    [ReducerMethod]
    public static AuthState OnForgotPasswordFailAction(
        AuthState state,
        ForgotPasswordFailAction action) =>
        state with
        {
            IsLoading = false,
            IsEmailForgotPasswordSent = false,
            ErrorMessage = action.ErrorMessage
        };
}