using WasmBaseProjectApp.Services;
using WasmBaseProjectApp.ViewModels;

namespace WasmBaseProjectApp.Store.Employees;

public record EmployeesState(bool IsLoading, EmployeeListViewModel[]? Employees, EmployeeEditViewModel? SelectedEmployee);