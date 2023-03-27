namespace BaseProject.Infrastructure.ViewModels.Auth;

public class LoginWithEmailViewModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class LoginWithPhoneNumberViewModel
{
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
}