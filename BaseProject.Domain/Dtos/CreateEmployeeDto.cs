namespace BaseProject.Domain.Dtos;

public record CreateEmployeeDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? Birthdate { get; set; }
};