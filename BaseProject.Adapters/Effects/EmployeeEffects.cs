using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Employees;
using BaseProject.Infrastructure.ViewModels;
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
                dispatcher.Dispatch(
                    new GetEmployeesFailedAction($"Failed loading employees: employees is null"));

            var viewModel = employees!
                .Select(e =>
                    new EmployeeListViewModel(e.Id, $"{e.FirstName} {e.LastName}", e.Email, e.Status,
                        $"{e.Birthdate:dd/MM/yyyy}"))
                .ToArray();

            dispatcher.Dispatch(new GetEmployeesSuccessAction(viewModel));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed loading employees");
            dispatcher.Dispatch(new GetEmployeesFailedAction("Failed loading employees"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(GetOneEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new GetOneEmployeeFailedAction("Employee id is null"));

            var employee = await _employeeService.GetOneAsync(action.Id!.Value);

            if (employee is null)
                dispatcher.Dispatch(new GetOneEmployeeFailedAction("Employee is null"));

            var employeeViewModel = new EmployeeEditViewModel
            {
                FirstName = employee?.FirstName, LastName = employee?.LastName, Email = employee?.Email,
                Birthdate = employee?.Birthdate, Address = employee?.Address, Note = employee?.Note
            };

            dispatcher.Dispatch(new GetOneEmployeeSuccessAction(employeeViewModel));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed loading employee");
            dispatcher.Dispatch(new GetOneEmployeeFailedAction("Failed loading employee"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(CreateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = new Employee(0, action.Dto.FirstName!, action.Dto.LastName!, action.Dto.Email!,
                action.Dto.Birthdate!.Value);

            await _employeeService.CreateAsync(employee);

            dispatcher.Dispatch(new CreateEmployeeSuccessAction());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed creating employee");
            dispatcher.Dispatch(new EmployeeFailedAction("Failed creating employee"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            var employee = new Employee(action.Id, action.Employee.FirstName!, action.Employee.LastName!,
                action.Employee.Email!, action.Employee.Birthdate!.Value)
                .AddOrUpdateNote(action.Employee.Note!)
                .AddOrUpdateAddress(action.Employee.Address!);

            await _employeeService.UpdateAsync(action.Id, employee);

            dispatcher.Dispatch(new UpdateEmployeeSuccessAction(action.Id, action.Employee));
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
                dispatcher.Dispatch(new EmployeeFailedAction("Employee is null"));
                return;
            }
            
            var status = employee.Status == EmployeeStatus.Active
                ? EmployeeStatus.Inactive
                : EmployeeStatus.Active;
            
            employee.ChangeStatus(status);
            
            await _employeeService.UpdateStatusAsync(action.Id, employee);

            dispatcher.Dispatch(new UpdateEmployeeStatusSuccessAction(action.Id, employee.Status));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"Failed updating employee status");
            dispatcher.Dispatch(new EmployeeFailedAction("Failed updating employee status"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(DeleteEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee id is null"));

            await _employeeService.DeleteAsync(action.Id!.Value);

            dispatcher.Dispatch(new DeleteEmployeeSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed deleting employee");
            dispatcher.Dispatch(new EmployeeFailedAction("Failed deleting employee"));
        }
    }
}