using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.Store.Employees;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public class EmployeeFacade
{
    private readonly IDispatcher _dispatcher;

    public EmployeeFacade(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void GetEmployees()
    {
        _dispatcher.Dispatch(new GetEmployeesAction());
    }
    
    public void GetOneEmployee(int id)
    {
        _dispatcher.Dispatch(new GetOneEmployeeAction(id));
    }
    
    public void CreateEmployee(CreateEmployeeDto employee)
    {
        _dispatcher.Dispatch(new CreateEmployeeAction(employee));
    }
    
    public void UpdateEmployee(int id, UpdateEmployeeDto updateEmployee)
    {
        _dispatcher.Dispatch(new UpdateEmployeeAction(id, updateEmployee));
    }
    
    public void UpdateEmployeeStatus(int id)
    {
        _dispatcher.Dispatch(new UpdateEmployeeStatusAction(id));
    }
    
    public void DeleteEmployee(int id)
    {
        _dispatcher.Dispatch(new DeleteEmployeeAction(id));
    }
}