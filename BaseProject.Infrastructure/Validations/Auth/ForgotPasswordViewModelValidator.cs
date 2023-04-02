using BaseProject.Infrastructure.ViewModels.Auth;
using FluentValidation;

namespace BaseProject.Infrastructure.Validations.Auth;

public sealed class ForgotPasswordViewModelValidator
    : AbstractValidator<ForgotPasswordViewModel>
{
    public ForgotPasswordViewModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not valid.")
            .NotNull()
            .WithMessage("Email is required.");
    }
}