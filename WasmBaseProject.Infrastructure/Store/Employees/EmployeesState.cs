using Fluxor.Persist.Storage;
using WasmBaseProject.Infrastructure.ViewModels;

namespace WasmBaseProject.Infrastructure.Store.Employees;

[SkipPersistState]
public record EmployeesState(bool IsLoading, EmployeeListViewModel[]? Employees, EmployeeEditViewModel? SelectedEmployee);