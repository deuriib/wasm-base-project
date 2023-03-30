using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Dtos;

public sealed record ListEmployeeDto(int Id, 
    string FullName, 
    string Email, 
    EmployeeStatus Status);