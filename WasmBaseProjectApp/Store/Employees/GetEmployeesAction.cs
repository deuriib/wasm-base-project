using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public class GetEmployeesAction
    { }

    public class GetEmployeesSuccessAction
    {
        public Employee[] Employees { get; }

        public GetEmployeesSuccessAction(Employee[] employees)
        {
            Employees = employees;
        }
    }

    public class GetEmployeesFailedAction
    {
        public string ErrorMessage { get; }

        public GetEmployeesFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

}
