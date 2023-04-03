using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.Store.Employees;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public class EmployeeFacade : IFacade
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
    
    public void GetOneEmployee(long id)
    {
        _dispatcher.Dispatch(new GetOneEmployeeAction(id));
    }
    
    public void CreateEmployee(CreateEmployeeDto employee)
    {
        _dispatcher.Dispatch(new CreateEmployeeAction(employee));
    }
    
    public void UpdateEmployee(long id, EmployeeDto employee)
    {
        _dispatcher.Dispatch(new UpdateEmployeeAction(id, employee));
    }
    
    public void UpdateEmployeeStatus(long id)
    {
        _dispatcher.Dispatch(new UpdateEmployeeStatusAction(id));
    }
    
    public void DeleteEmployee(long id)
    {
        _dispatcher.Dispatch(new DeleteEmployeeAction(id));
    }
    
    public void OpenCreateEmployeeModal()
    {
        _dispatcher.Dispatch(new OpenCreateEmployeeModalAction());
    }
    
    public void CloseCreateEmployeeModal()
    {
        _dispatcher.Dispatch(new CloseCreateEmployeeAction());
    }
    
    public void OpenDetailsEmployeeModal(long employeeId)
    {
        _dispatcher.Dispatch(
            new OpenDetailsEmployeeModal(employeeId));
    }
    
    public void CloseDetailsEmployeeModal()
    {
        _dispatcher.Dispatch(new CloseDetailsEmployeeModal());
    }
    
    public void OpenEditEmployeeModal(long employeeId)
    {
        _dispatcher.Dispatch(
            new OpenEditEmployeeModal(employeeId));
    }
    
    public void CloseEditEmployeeModal()
    {
        _dispatcher.Dispatch(new CloseEditEmployeeModal());
    }
    
    public void OpenDeleteEmployeeModal(long employeeId, string employeeName)
    {
        _dispatcher.Dispatch(
            new OpenDeleteEmployeeModalAction(employeeId, employeeName));
    }
    
    public void CloseDeleteEmployeeModal()
    {
        _dispatcher.Dispatch(new CloseDeleteEmployeeModelAction());
    }
}