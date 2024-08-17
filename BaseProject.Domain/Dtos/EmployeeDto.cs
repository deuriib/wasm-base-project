using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Dtos;

public sealed record EmployeeDto
{
    public long Id { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public DateTime? Birthdate { get; set; }

    public EmployeeStatus? Status { get; set; }

    public string? Address { get; set; }

    public string? Note { get; set; }

}