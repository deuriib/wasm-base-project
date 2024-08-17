namespace BaseProject.Infrastructure.Store.Auth;

public sealed record LoginWithEmailAndPasswordAction(
    string Email,
    string Password,
    bool RememberMe = false,
    string? ReturnUrl = null);