using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public record EmployeesState(bool IsLoading, Employee[] Employees, string ErrorMessage);
