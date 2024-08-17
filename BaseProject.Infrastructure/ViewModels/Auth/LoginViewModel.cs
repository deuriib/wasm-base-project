namespace BaseProject.Infrastructure.ViewModels.Auth;

public sealed record LoginWithEmailViewModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public bool RememberMe { get; set; }
}

public sealed record LoginWithPhoneNumberViewModel
{
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
}