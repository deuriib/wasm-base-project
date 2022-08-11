using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Domain.Dtos;

public record EmployeeListDto(int Id, string FullName, string Email, EmployeeStatus Status, DateTime Birthdate);