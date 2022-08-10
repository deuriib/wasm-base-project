namespace WasmBaseProject.Domain.Dtos;

public record EditEmployeeDto(string? FirstName, string? LastName, string? Address, string? Note, DateTime? Birthdate);