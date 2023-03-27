using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Auth;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace BaseProject.Adapters.Effects;

public class AuthEffects
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AuthEffects> _logger;

    public AuthEffects(IAuthenticationService authenticationService, ILogger<AuthEffects> logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
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
                dispatcher.Dispatch(new LoginWithEmailAndPasswordActionFailed("Credentials are invalid"));
                return;
            }

            dispatcher.Dispatch(new LoginWithEmailAndPasswordActionSuccess(session));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred trying to sign in");
            
            dispatcher.Dispatch(
                new LoginWithEmailAndPasswordActionFailed($"An error occurred trying to login in"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(LoginWithGoogleAction action, IDispatcher dispatcher)
    {
        try
        {
            var session = await _authenticationService
                .SignInWithGoogleAsync();

            if (session is null)
            {
                dispatcher.Dispatch(new LoginWithGoogleActionFailed("Credentials are invalid"));
                return;
            }

            dispatcher.Dispatch(new LoginWithGoogleActionSuccess(session));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred trying to sign in with google");
            
            dispatcher.Dispatch(
                new LoginWithGoogleActionFailed($"An error occurred trying to sig in with google: {ex.Message}"));
        }
    }

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

            dispatcher.Dispatch(
                new RegisterActionSuccess(session));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred trying to register");
            
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

            dispatcher.Dispatch(new LogoutActionSuccess());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred trying to register");
            
            dispatcher.Dispatch(
                new LogoutActionFailed("An error occurred trying to register"));
        }
    }
}