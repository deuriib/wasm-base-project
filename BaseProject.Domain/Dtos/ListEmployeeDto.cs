using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Dtos;

public record ListEmployeeDto(int Id, string FullName, string Email, EmployeeStatus Status, DateTime Birthdate);