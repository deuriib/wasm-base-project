using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Domain.Dtos;

public record EmployeeListDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public EmployeeStatus? Status { get; set; }

    public DateTime Birthdate { get; set; }
}