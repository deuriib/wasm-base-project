using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public record EmployeesState(bool IsLoading,EmployeeListDto[]? Employees, EditEmployeeDto? SelectedEmployee);