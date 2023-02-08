using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Infrastructure.ViewModels;

public record EmployeeListViewModel(int Id, string FullName, string Email, EmployeeStatus Status, string Birthdate);