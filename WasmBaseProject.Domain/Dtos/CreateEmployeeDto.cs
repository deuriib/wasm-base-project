namespace WasmBaseProject.Domain.Dtos;

public record CreateEmployeeDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }= string.Empty;
    public string Email { get; set; }= string.Empty;
    public string? Address { get; set; }
    public string? Note { get; set; }
    public DateTime? Birthdate { get; set; }
};