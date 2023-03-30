using BaseProject.Infrastructure.ViewModels.Auth;
using FluentValidation;

namespace BaseProject.Infrastructure.Validations.Auth;

public class LoginWithEmailViewModelValidator : AbstractValidator<LoginWithEmailViewModel>
{
    public LoginWithEmailViewModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Provided a valid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(10)
            .WithMessage("Password must be at least 10 characters long");
    }
}