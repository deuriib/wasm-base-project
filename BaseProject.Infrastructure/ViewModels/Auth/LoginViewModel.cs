namespace BaseProject.Infrastructure.ViewModels.Auth;

public record LoginWithEmailViewModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public record LoginWithPhoneNumberViewModel
{
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
}