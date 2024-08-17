namespace BaseProject.Infrastructure.ViewModels.Auth;

public sealed record RegisterViewModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}