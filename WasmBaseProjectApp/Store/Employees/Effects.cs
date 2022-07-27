using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public class Effects
{
    private readonly EmployeeService _service;

    public Effects(EmployeeService service)
    {
        _service = service;
    }

    [EffectMethod]
    public async Task HandleAsync(GetEmployeesAction action, IDispatcher dispatcher)
    {
        try
        {
            var employees = await _service.GetAllAsync();

            dispatcher.Dispatch(new GetEmployeesSuccessAction(employees));
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

            dispatcher.Dispatch(new GetOneEmployeeSuccessAction(employee));
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

            await _service.AddOneAsync(action.Dto!);

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

            var dto = new EditEmployeeDto(action.Employee?.FirstName, action.Employee?.LastName,
                action.Employee?.Address, action.Employee?.Note, action.Employee?.Birthdate);
            
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

            if (action.Dto is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee is null"));

            if(action.Dto?.Status is null)
                dispatcher.Dispatch(new EmployeeFailedAction("Employee status is null"));

            action.Dto!.Status = action.Dto.Status!.Equals(EmployeeStatus.Active) ? EmployeeStatus.Inactive : EmployeeStatus.Active;


            await _service.UpdateStatusAsync(action.Id!.Value, action.Dto!);

            dispatcher.Dispatch(new UpdateEmployeeStatusSuccessAction(action.Id, action.Dto!.Status));
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