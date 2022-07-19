using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
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
        public async Task HandleAsync(UpdateEmployeeStatusAction action, IDispatcher dispatcher)
        {
            try
            {
                bool newStatus = !action.CurrentStatus;
                await _service.UpdateStatusAsync(action.Id, newStatus);

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
                await _service.DeleteAsync(action.Id);

                dispatcher.Dispatch(new DeleteEmployeeSuccessAction(action.Id));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new DeleteEmployeeFailedAction(ex.GetBaseException().Message));
            }
        }
    }
}