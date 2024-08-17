using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Infrastructure.Store.Employees;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public sealed class EmployeeFacade(IDispatcher dispatcher) : IFacade
{
    public void GetEmployees()
    {
        dispatcher.Dispatch(new GetEmployeesAction());
    }

    public void GetOneEmployee(long id)
    {
        dispatcher.Dispatch(new GetOneEmployeeAction(id));
    }

    public void CreateEmployee(CreateEmployeeDto employee)
    {
        dispatcher.Dispatch(new CreateEmployeeAction(employee));
    }

    public void UpdateEmployee(long id, EmployeeDto employee)
    {
        dispatcher.Dispatch(new UpdateEmployeeAction(id, employee));
    }

    public void UpdateEmployeeStatus(long id, EmployeeStatus status)
    {
        dispatcher.Dispatch(new UpdateEmployeeStatusAction(id, status));
    }

    public void DeleteEmployee(long id)
    {
        dispatcher.Dispatch(new DeleteEmployeeAction(id));
    }

    public void OpenCreateEmployeeModal()
    {
        dispatcher.Dispatch(new OpenCreateEmployeeModalAction());
    }

    public void CloseCreateEmployeeModal()
    {
        dispatcher.Dispatch(new CloseCreateEmployeeAction());
    }

    public void OpenDetailsEmployeeModal(long employeeId)
    {
        dispatcher.Dispatch(
            new OpenDetailsEmployeeModal(employeeId));
    }

    public void CloseDetailsEmployeeModal()
    {
        dispatcher.Dispatch(new CloseDetailsEmployeeModal());
    }

    public void OpenEditEmployeeModal(long employeeId)
    {
        dispatcher.Dispatch(
            new OpenEditEmployeeModal(employeeId));
    }

    public void CloseEditEmployeeModal()
    {
        dispatcher.Dispatch(new CloseEditEmployeeModal());
    }

    public void OpenDeleteEmployeeModal(long employeeId, string employeeName)
    {
        dispatcher.Dispatch(
            new OpenDeleteEmployeeModalAction(employeeId, employeeName));
    }

    public void CloseDeleteEmployeeModal()
    {
        dispatcher.Dispatch(new CloseDeleteEmployeeModelAction());
    }
}