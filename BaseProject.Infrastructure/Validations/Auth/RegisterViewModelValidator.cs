using BaseProject.Infrastructure.ViewModels.Auth;
using FluentValidation;

namespace BaseProject.Infrastructure.Validations.Auth;

public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterViewModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Provided a valid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(12)
            .WithMessage("Password must be at least 12 characters long");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password is required")
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");
    }   
}