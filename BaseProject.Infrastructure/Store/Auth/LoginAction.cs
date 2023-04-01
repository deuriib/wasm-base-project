namespace BaseProject.Infrastructure.Store.Auth;

public record LoginWithEmailAndPasswordAction(string Email, 
    string Password, 
    bool RememberMe = false, 
    string ReturnUrl = "/");