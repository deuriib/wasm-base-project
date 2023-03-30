using BaseProject.Domain.Dtos;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Employees;

[SkipPersistState]
[FeatureState]
public sealed record EmployeesState
{
    public bool IsLoading { get; init; }
    
    public ListEmployeeDto[] Employees { get; init; }
    
    public EmployeeDto? SelectedEmployee { get; init; }
    
    public bool IsLoadingEmployee { get; init; }
    
    public bool IsCreateEmployeeModalOpen { get; init; }
    
    public bool IsDeleteEmployeeModalOpen { get; init; }
    
    public string ErrorMessage { get; init; }

    private EmployeesState()
    {
        IsLoading = false;
        ErrorMessage = string.Empty;
        Employees = Array.Empty<ListEmployeeDto>();
        SelectedEmployee = null;
        IsLoadingEmployee = false;
        IsCreateEmployeeModalOpen = false;
        IsDeleteEmployeeModalOpen = false;
    }
}