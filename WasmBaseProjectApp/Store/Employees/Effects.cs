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
                var employees = await _service.GetEmployeesAsync();
                dispatcher.Dispatch(new GetEmployeesSuccessAction(employees));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new GetEmployeesFailedAction(ex.Message));
            }
        }
    }
}
