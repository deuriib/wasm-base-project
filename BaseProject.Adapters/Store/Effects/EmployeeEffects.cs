using BaseProject.Adapters.Services;
using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Infrastructure.Store.Employees;
using BaseProject.Infrastructure.ViewModels;
using Fluxor;

namespace BaseProject.Adapters.Store.Effects;

public class EmployeeEffects
{
    private readonly EmployeeService _service;

    public EmployeeEffects(EmployeeService service)
    {
        _service = service;
    }

    [EffectMethod(typeof(GetEmployeesAction))]
    public async Task HandleAsync(IDispatcher dispatcher)
    {
        try
        {
            var employees = await _service.GetAllAsync();

            if (employees is null)
                dispatcher.Dispatch(
                    new GetEmployeesFailedAction($"Failed loading employees: employees is null"));

            var viewModel = employees!
                .Select(e =>
                    new EmployeeListViewModel(e.Id, e.FullName, e.Email, e.Status, $"{e.Birthdate:dd/MM/yyyy}"))
                .ToArray();

            dispatcher.Dispatch(new GetEmployeesSuccessAction(viewModel));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new GetEmployeesFailedAction($"Failed loading employees: {ex.Message}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(GetOneEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new GetOneEmployeeFailedAction("Employee id is null"));

            var employee = await _service.GetOneAsync(action.Id!.Value);

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
            dispatcher.Dispatch(new GetOneEmployeeFailedAction($"Failed loading employee: {ex.Message}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(CreateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Dto is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee is null"));

            await _service.CreateAsync(action.Dto!);

            dispatcher.Dispatch(new CreateEmployeeSuccessAction());
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new EmployeeFailedAction($"Failed creating employee: {ex.Message}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee id is null"));

            if (action.Employee is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee is null"));

            var dto = new EditEmployeeDto(action.Employee?.FirstName!, action.Employee?.LastName!,
                action.Employee?.Email!,
                action.Employee?.Address, action.Employee?.Note, action.Employee!.Birthdate!.Value);

            await _service.UpdateAsync(action.Id!.Value, dto);

            dispatcher.Dispatch(new UpdateEmployeeSuccessAction(action.Id, action.Employee));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new EmployeeFailedAction($"Failed updating employee: {ex.Message}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeStatusAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee id is null"));

            await _service.UpdateStatusAsync(action.Id!.Value, action.Dto!);

            dispatcher.Dispatch(new UpdateEmployeeStatusSuccessAction(action.Id, action.Dto.Status));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new EmployeeFailedAction($"Failed updating employee status: {ex.Message}"));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(DeleteEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee id is null"));

            await _service.DeleteAsync(action.Id!.Value);

            dispatcher.Dispatch(new DeleteEmployeeSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new EmployeeFailedAction($"Failed deleting employee: {ex.Message}"));
        }
    }
}