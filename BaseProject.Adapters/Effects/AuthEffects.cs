using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Auth;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BaseProject.Adapters.Effects;

public class AuthEffects
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AuthEffects> _logger;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthEffects(
        IAuthenticationService authenticationService,
        ILogger<AuthEffects> logger,
        AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationService = authenticationService;
        _logger = logger;
        _authenticationStateProvider = authenticationStateProvider;
    }

    [EffectMethod]
    public async Task HandleAsync(LoginWithEmailAndPasswordAction action, IDispatcher dispatcher)
    {
        try
        {
            var session = await _authenticationService
                .SignInWithEmailAndPasswordAsync(action.Email, action.Password);

            if (session is null)
            {
                dispatcher.Dispatch(new LoginFailedAction("Credentials are invalid"));
                return;
            }

            await _authenticationStateProvider.GetAuthenticationStateAsync();

            dispatcher.Dispatch(new LoginSuccessAction(session));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "LoginWithEmailAndPasswordAction");

            dispatcher.Dispatch(
                new LoginFailedAction($"An error occurred trying to login in"));
        }
    }

    // [EffectMethod]
    // public async Task HandleAsync(LoginWithGoogleAction action, IDispatcher dispatcher)
    // {
    //     try
    //     {
    //         var session = await _authenticationService
    //             .SignInWithGoogleAsync();
    //
    //         if (session is null)
    //         {
    //             dispatcher.Dispatch(new LoginFailedAction("Credentials are invalid"));
    //             return;
    //         }
    //
    //         await _authenticationStateProvider.GetAuthenticationStateAsync();
    //
    //         dispatcher.Dispatch(new LoginSuccessAction(session));
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "An error occurred trying to sign in with google");
    //
    //         dispatcher.Dispatch(
    //             new LoginFailedAction($"An error occurred trying to sig in with google: {ex.Message}"));
    //     }
    // }

    [EffectMethod]
    public async Task HandleAsync(RegisterAction action, IDispatcher dispatcher)
    {
        try
        {
            var session = await _authenticationService
                .SignUpAsync(action.Email, action.Password);

            if (session is null)
            {
                dispatcher.Dispatch(new RegisterActionFailed("Credentials are invalid"));
                return;
            }

            await _authenticationStateProvider.GetAuthenticationStateAsync();

            dispatcher.Dispatch(
                new RegisterActionSuccess(session));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "RegisterAction");

            dispatcher.Dispatch(
                new RegisterActionFailed("An error occurred trying to register"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(LogoutAction action, IDispatcher dispatcher)
    {
        try
        {
            await _authenticationService
                .SignOutAsync();

            await _authenticationStateProvider.GetAuthenticationStateAsync();

            dispatcher.Dispatch(new LogoutActionSuccess(action.ReturnUrl));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "LogoutAction");

            dispatcher.Dispatch(
                new LogoutActionFailed("An error occurred trying to register"));
        }
    }
    
    [EffectMethod]
    public async Task HandleAsync(ForgotPasswordAction action, IDispatcher dispatcher)
    {
        try
        {
            await _authenticationService
                .SendPasswordResetEmailAsync(action.Email);

            dispatcher.Dispatch(new ForgotPasswordSuccessAction());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ForgotPasswordAction");

            dispatcher.Dispatch(
                new ForgotPasswordFailAction(
                    "An error occurred trying to sending password reset email"));
        }
    }
}