using AutoBogus;
using BaseProject.Domain.Dtos;

namespace BaseProject.Infrastructure.Fakers;

public sealed class CreateEmployeeDtoFaker : AutoFaker<CreateEmployeeDto>
{
    public CreateEmployeeDtoFaker()
    {
        RuleFor(x => x.FirstName, f => f.Person.FirstName);
        RuleFor(x => x.LastName, f => f.Person.LastName);
        RuleFor(x => x.Email, f => f.Person.Email);
        RuleFor(x => x.Birthdate, f => f.Date
            .Past(20, new DateTime(1990, 1, 1)));
    }
}