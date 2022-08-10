using WasmBaseProject.Infrastructure.ViewModels;

namespace WasmBaseProject.Infrastructure.Store.Employees;

public record EmployeesState(bool IsLoading, EmployeeListViewModel[]? Employees, EmployeeEditViewModel? SelectedEmployee);