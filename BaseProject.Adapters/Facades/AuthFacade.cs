using BaseProject.Infrastructure.Store.Auth;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public sealed class AuthFacade(IDispatcher dispatcher) : IFacade
{
    public void LoginWithEmailAndPassword(string email,
        string password,
        bool rememberMe = false,
        string returnUrl = "")
    {
        dispatcher.Dispatch(new LoginWithEmailAndPasswordAction(email, password, rememberMe, returnUrl));
    }

    public void LoginWithGoogle()
    {
        dispatcher.Dispatch(new LoginWithGoogleAction());
    }

    public void Logout(string returnUrl)
    {
        dispatcher.Dispatch(new LogoutAction(returnUrl));
    }

    public void RegisterWithEmailAndPassword(string email, string password)
    {
        dispatcher.Dispatch(new RegisterAction(email, password));
    }

    public void ForgotPassword(string email)
    {
        dispatcher.Dispatch(new ForgotPasswordAction(email));
    }

    public void ResetForgotPassword()
    {
        dispatcher.Dispatch(new ForgotPasswordResetAction());
    }

    public void TogglePasswordInputVisibility()
    {
        dispatcher.Dispatch(new TogglePasswordInputVisibilityAction());
    }
}