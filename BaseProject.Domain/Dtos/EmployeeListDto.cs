using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Dtos;

public record EmployeeListDto(int Id, string FullName, string Email, EmployeeStatus Status, DateTime Birthdate);