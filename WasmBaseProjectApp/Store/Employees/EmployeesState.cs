using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public record EmployeesState(bool IsLoading,string? ErrorMessage, Employee[]? Employees);