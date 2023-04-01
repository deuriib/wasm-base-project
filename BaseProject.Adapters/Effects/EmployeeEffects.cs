using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Employees;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace BaseProject.Adapters.Effects;

public class EmployeeEffects
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeEffects> _logger;

    public EmployeeEffects(IEmployeeService employeeService, ILogger<EmployeeEffects> logger)
    {
        _employeeService = employeeService;
        _logger = logger;
    }

    [EffectMethod(typeof(GetEmployeesAction))]
    public async Task HandleAsync(IDispatcher dispatcher)
    {
        try
        {
            var employees = await _employeeService.GetAllAsync();

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
                Status = e.Status
            }).ToArray()));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetEmployeesFailedAction");

            dispatcher.Dispatch(new GetEmployeesFailedAction("Failed loading employees"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(GetOneEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = await _employeeService.GetOneAsync(action.Id);

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
            _logger.LogError(ex, "GetOneEmployeeFailedAction");

            dispatcher.Dispatch(new GetOneEmployeeFailedAction("Failed loading employee with id {action.Id}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(CreateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = new Employee(0, action.Dto.FirstName, action.Dto.LastName, action.Dto.Email,
                action.Dto.Birthdate!.Value, EmployeeStatus.Active);
            
            var newEmployee = await _employeeService.CreateAsync(employee);

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
                Status = newEmployee.Status
            };  
            
            dispatcher.Dispatch(new CreateEmployeeSuccessAction(employeeDto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateEmployeeFailAction");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed creating employee"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = await _employeeService.GetOneAsync(action.EmployeeId);
            
            if(employee is null)
            {
                dispatcher.Dispatch(
                    new EmployeeFailedAction($"Employee with id {action.EmployeeId} not found"));
                return;
            }
            
            employee = employee with
            {
                FirstName = action.Employee.FirstName,
                LastName = action.Employee.LastName,
                Email = action.Employee.Email,
                Address = action.Employee.Address,
                Note = action.Employee.Note,
                Birthdate = action.Employee.Birthdate!.Value
            };
            
            await _employeeService.UpdateAsync(action.EmployeeId, employee);

            dispatcher.Dispatch(new UpdateEmployeeSuccessAction(action.EmployeeId, action.Employee));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed updating employee");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed updating employee"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeStatusAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = await _employeeService.GetOneAsync(action.Id);
            
            if (employee is null)
            {
                dispatcher.Dispatch(new EmployeeFailedAction("Employee not found null"));
                return;
            }

            var status = employee.Status == EmployeeStatus.Active
                ? EmployeeStatus.Inactive
                : EmployeeStatus.Active;
            
            employee = employee with { Status = status };

            await _employeeService.UpdateAsync(action.Id, employee);

            dispatcher.Dispatch(new UpdateEmployeeStatusSuccessAction(action.Id, employee.Status));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed updating employee status");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed updating employee status"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(DeleteEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            await _employeeService.DeleteAsync(action.Id);

            dispatcher.Dispatch(new DeleteEmployeeSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed deleting employee");

            dispatcher.Dispatch(new EmployeeFailedAction("Failed deleting employee"));
        }
    }
}