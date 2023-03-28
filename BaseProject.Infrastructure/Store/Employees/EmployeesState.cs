using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.ViewModels;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Employees;

[SkipPersistState]
[FeatureState]
public class EmployeesState
{
    public EmployeesState(bool isLoading, 
        ListEmployeeDto[] employees, 
        UpdateEmployeeDto? selectedEmployee,
        bool isLoadingEmployee)
    {
        IsLoading = isLoading;
        Employees = employees;
        SelectedEmployee = SelectedEmployee;
        IsLoadingEmployee = isLoadingEmployee;
    }

    public bool IsLoading { get;  }
    public ListEmployeeDto[] Employees { get;  }
    public UpdateEmployeeDto? SelectedEmployee { get;  }
    public bool IsLoadingEmployee { get;  }

    private EmployeesState()
    {
        IsLoading = false;
        Employees = Array.Empty<ListEmployeeDto>();
        SelectedEmployee = null;
        IsLoadingEmployee = false;
    }
}