namespace BaseProject.Domain.Dtos;

public record EditEmployeeDto(string? FirstName, string? LastName, string? Email,
    string? Address, string? Note, DateTime? Birthdate);