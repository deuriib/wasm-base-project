using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Auth;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BaseProject.Adapters.Effects;

public sealed class AuthEffects(
        IAuthenticationService authenticationService,
        ILogger<AuthEffects> logger,
        AuthenticationStateProvider authenticationStateProvider)
{

    [EffectMethod]
    public async Task HandleAsync(LoginWithEmailAndPasswordAction action, IDispatcher dispatcher)
    {
        try
        {
            var session = await authenticationService
                .SignInWithEmailAndPasswordAsync(action.Email, action.Password);

            if (session is null)
            {
                dispatcher.Dispatch(new LoginFailedAction("Credentials are invalid"));
                return;
            }

            dispatcher.Dispatch(new LoginSuccessAction(session));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LoginWithEmailAndPasswordAction");

            dispatcher.Dispatch(
                new LoginFailedAction($"An error occurred trying to login in"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(LoginSuccessAction action, IDispatcher _)
    {
        await authenticationStateProvider.GetAuthenticationStateAsync();
    }

    [EffectMethod]
    public async Task HandleAsync(RegisterAction action, IDispatcher dispatcher)
    {
        try
        {
            var session = await authenticationService
                .SignUpAsync(action.Email, action.Password);

            if (session is null)
            {
                dispatcher.Dispatch(new RegisterActionFailed("Credentials are invalid"));
                return;
            }



            dispatcher.Dispatch(
                new RegisterActionSuccess(session));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "RegisterAction");

            dispatcher.Dispatch(
                new RegisterActionFailed("An error occurred trying to register"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(RegisterActionSuccess action, IDispatcher dispatcher)
    {
        await authenticationStateProvider.GetAuthenticationStateAsync();
    }

    [EffectMethod]
    public async Task HandleAsync(LogoutAction action, IDispatcher dispatcher)
    {
        try
        {
            await authenticationService
                .SignOutAsync();

            await authenticationStateProvider.GetAuthenticationStateAsync();

            dispatcher.Dispatch(new LogoutActionSuccess(action.ReturnUrl));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LogoutAction");

            dispatcher.Dispatch(
                new LogoutActionFailed("An error occurred trying to register"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(ForgotPasswordAction action, IDispatcher dispatcher)
    {
        try
        {
            await authenticationService
                .SendPasswordResetEmailAsync(action.Email);

            dispatcher.Dispatch(new ForgotPasswordSuccessAction());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "ForgotPasswordAction");

            dispatcher.Dispatch(
                new ForgotPasswordFailAction(
                    "An error occurred trying to sending password reset email"));
        }
    }
}