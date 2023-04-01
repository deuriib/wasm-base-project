using BaseProject.Domain.Dtos;
using BaseProject.Domain.Models;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Employees;

[SkipPersistState]
[FeatureState]
public sealed record EmployeesState(
    bool IsLoading,
    EmployeeDto[] Employees,
    EmployeeDto? SelectedEmployee,
    bool IsLoadingEmployee,
    bool IsCreateEmployeeModalOpen,
    bool IsDeleteEmployeeModalOpen,
    bool IsDetailsEmployeeModalOpen,
    bool IsEditEmployeeModalOpen,
    string ErrorMessage)
{
    private EmployeesState()
        : this(
            false,
            Array.Empty<EmployeeDto>(),
            null,
            false,
            false,
            false,
            false,
            false,
            string.Empty)
    {
    }
}