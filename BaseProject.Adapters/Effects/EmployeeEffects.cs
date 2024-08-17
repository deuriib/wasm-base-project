using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Employees;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace BaseProject.Adapters.Effects;

public sealed class EmployeeEffects(IEmployeeService employeeService, ILogger<EmployeeEffects> logger)
{

    [EffectMethod(typeof(GetEmployeesAction))]
    public async Task HandleAsync(IDispatcher dispatcher)
    {
        try
        {
            var employees = await employeeService.GetAllAsync();

            if (employees is null)
            {
                dispatcher.Dispatch(new GetEmployeesFailedAction("There are no employees in the system"));
                return;
            }

            dispatcher.Dispatch(new GetEmployeesSuccessAction(employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Birthdate = e.Birthdate,
                Address = e.Address,
                Note = e.Note,
                Status = EmployeeStatus.FromValue(e.Status)
            }).ToArray()));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetEmployeesFailedAction");

            dispatcher.Dispatch(new GetEmployeesFailedAction("Failed loading employees"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(GetOneEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = await employeeService.GetOneAsync(action.Id);

            if (employee is null)
            {
                dispatcher.Dispatch(
                    new GetOneEmployeeFailedAction("Employee with not found"));
                return;
            }

            var employeeDto = new EmployeeDto
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Birthdate = employee.Birthdate,
                Address = employee.Address,
                Note = employee.Note
            };

            dispatcher.Dispatch(new GetOneEmployeeSuccessAction(employeeDto));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetOneEmployeeFailedAction");

            dispatcher.Dispatch(new GetOneEmployeeFailedAction("Failed loading employee with id {action.Id}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(CreateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = new Employee
            {
                FirstName = action.Dto.FirstName,
                LastName = action.Dto.LastName,
                Email = action.Dto.Email,
                Birthdate = action.Dto.Birthdate!.Value
            };

            var newEmployee = await employeeService.CreateAsync(employee);

            if (newEmployee is null)
            {
                dispatcher.Dispatch(new EmployeeFailedAction("Could not create employee"));
                return;
            }

            var employeeDto = new EmployeeDto
            {
                Id = newEmployee.Id,
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Email = newEmployee.Email,
                Birthdate = newEmployee.Birthdate,
                Address = newEmployee.Address,
                Note = newEmployee.Note,
                Status = EmployeeStatus.FromValue(newEmployee.Status)
            };

            dispatcher.Dispatch(new CreateEmployeeSuccessAction(employeeDto));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CreateEmployeeFailAction");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed creating employee"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = new Employee
            {
                FirstName = action.Employee.FirstName,
                LastName = action.Employee.LastName,
                Email = action.Employee.Email,
                Birthdate = action.Employee.Birthdate!.Value,
                Address = action.Employee.Address,
                Note = action.Employee.Note,
            };

            var updatedEmployee = await employeeService.UpdateAsync(action.EmployeeId, employee);

            if (updatedEmployee is null)
            {
                dispatcher.Dispatch(
                    new EmployeeFailedAction($"Employee with id {action.EmployeeId} not found"));
                return;
            }

            var employeeDto = new EmployeeDto
            {
                Id = updatedEmployee.Id,
                FirstName = updatedEmployee.FirstName,
                LastName = updatedEmployee.LastName,
                Email = updatedEmployee.Email,
                Birthdate = updatedEmployee.Birthdate,
                Address = updatedEmployee.Address,
                Note = updatedEmployee.Note,
                Status = EmployeeStatus.FromValue(updatedEmployee.Status)
            };

            dispatcher.Dispatch(new UpdateEmployeeSuccessAction(action.EmployeeId, employeeDto));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed updating employee");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed updating employee"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeStatusAction action, IDispatcher dispatcher)
    {
        try
        {
            var status = action.Status == EmployeeStatus.Active ? false : true;

            var updatedEmployee = await employeeService.UpdateStatusAsync(action.Id, status);

            if (updatedEmployee is null)
            {
                dispatcher.Dispatch(new EmployeeFailedAction($"Employee with Id:{action.Id} not found"));
                return;
            }

            dispatcher.Dispatch(new UpdateEmployeeStatusSuccessAction(action.Id, EmployeeStatus.FromValue(updatedEmployee.Status)));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed updating employee status");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed updating employee status"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(DeleteEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            await employeeService.DeleteAsync(action.Id);

            dispatcher.Dispatch(new DeleteEmployeeSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed deleting employee");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed deleting employee"));
        }
    }
}