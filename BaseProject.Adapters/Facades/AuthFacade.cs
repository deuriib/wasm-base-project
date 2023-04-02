using BaseProject.Infrastructure.Store.Auth;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public class AuthFacade
{
    private readonly IDispatcher _dispatcher;
    public AuthFacade(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void LoginWithEmailAndPassword(string email, 
        string password, 
        bool rememberMe = false, 
        string returnUrl = "/")
    {
        _dispatcher.Dispatch(new LoginWithEmailAndPasswordAction(email, password, rememberMe, returnUrl));
    }
    
    public void LoginWithGoogle()
    {
        _dispatcher.Dispatch(new LoginWithGoogleAction());
    }
    
    public void Logout(string returnUrl)
    {
        _dispatcher.Dispatch(new LogoutAction(returnUrl));
    }
    
    public void RegisterWithEmailAndPassword(string email, string password)
    {
        _dispatcher.Dispatch(new RegisterAction(email, password));
    }
    
    public void ForgotPassword(string email)
    {
        _dispatcher.Dispatch(new ForgotPasswordAction(email));
    }
    
    public void ResetForgotPassword()
    {
        _dispatcher.Dispatch(new ForgotPasswordResetAction());
    }
    
    public void TogglePasswordInputVisibility()
    {
        _dispatcher.Dispatch(new TogglePasswordInputVisibilityAction());
    }
}