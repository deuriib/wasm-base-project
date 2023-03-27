using BaseProject.Infrastructure.ViewModels;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Employees;

[SkipPersistState]
[FeatureState]
public class EmployeesState
{
    public EmployeesState(bool isLoading, 
        EmployeeListViewModel[] employees, 
        EmployeeEditViewModel? selectedEmployee,
        bool isLoadingEmployee)
    {
        IsLoading = isLoading;
        Employees = employees;
        SelectedEmployee = SelectedEmployee;
        IsLoadingEmployee = isLoadingEmployee;
    }

    public bool IsLoading { get;  }
    public EmployeeListViewModel[] Employees { get;  }
    public EmployeeEditViewModel? SelectedEmployee { get;  }
    public bool IsLoadingEmployee { get;  }

    private EmployeesState()
    {
        IsLoading = false;
        Employees = Array.Empty<EmployeeListViewModel>();
        SelectedEmployee = null;
        IsLoadingEmployee = false;
    }
}