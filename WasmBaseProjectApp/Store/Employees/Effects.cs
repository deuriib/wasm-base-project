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
            dispatcher.Dispatch(new GetEmployeesFailedAction(ex.GetBaseException().Message));
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
            dispatcher.Dispatch(new GetOneEmployeeFailedAction(ex.GetBaseException().Message));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(CreateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Dto is null)
                dispatcher.Dispatch(new CreateEmployeeFailedAction("Employee is null"));

            await _service.AddOneAsync(action.Dto!);

            dispatcher.Dispatch(new CreateEmployeeSuccessAction());
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new CreateEmployeeFailedAction(ex.GetBaseException().Message));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new UpdateEmployeeFailedAction("Employee id is null"));

            if (action.Employee is null)
                dispatcher.Dispatch(new UpdateEmployeeFailedAction("Employee is null"));

            await _service.UpdateAsync(action.Id!.Value, action.Employee!);

            dispatcher.Dispatch(new UpdateEmployeeSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new UpdateEmployeeFailedAction(ex.GetBaseException().Message));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(UpdateEmployeeStatusAction action, IDispatcher dispatcher)
    {
        try
        {
            var dto = new UpdateEmployeeStatusDto { Status = !action.CurrentStatus };
            await _service.UpdateStatusAsync(action.Id, dto);

            dispatcher.Dispatch(new UpdateEmployeeStatusSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new UpdateEmployeeStatusFailedAction(ex.GetBaseException().Message));
        }
    }

    [EffectMethod]
    public async Task HandleAsync(DeleteEmployeeAction action, IDispatcher dispatcher)
    {
        try
        {
            if (action.Id is null)
                dispatcher.Dispatch(new DeleteEmployeeFailedAction("Employee id is null"));

            await _service.DeleteAsync(action.Id!.Value);

            dispatcher.Dispatch(new DeleteEmployeeSuccessAction(action.Id));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new DeleteEmployeeFailedAction(ex.GetBaseException().Message));
        }
    }
}