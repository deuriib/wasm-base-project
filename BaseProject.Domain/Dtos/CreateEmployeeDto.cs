using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Dtos;

public sealed record CreateEmployeeDto
{
    public string FirstName { get; set; } = default!;
    
    public string LastName { get; set; } = default!;
    
    public string Email { get; set; } = default!;
    
    public DateTime? Birthdate { get; set; }
};