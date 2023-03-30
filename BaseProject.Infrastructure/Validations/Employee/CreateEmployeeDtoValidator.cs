using BaseProject.Domain.Dtos;
using FluentValidation;

namespace BaseProject.Infrastructure.Validations.Employee;

public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required")
            .MaximumLength(20)
            .WithMessage("First name must be less than 20 characters")
            .MinimumLength(3)
            .WithMessage("First name must be at least 3 characters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required")
            .MaximumLength(20)
            .WithMessage("Last name must be less than 20 characters")
            .MinimumLength(3)
            .WithMessage("Last name must be at least 3 characters");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Please provide a valid email address");

        RuleFor(x => x.Birthdate)
            .NotEmpty()
            .WithMessage("Birthdate is required")
            .LessThan(DateTime.Now.AddYears(-18))
            .WithMessage("Employee must be at least 18 years old");
    }
}