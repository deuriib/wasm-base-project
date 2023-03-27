using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees
{
    public record GetEmployeesAction;

    public record GetEmployeesSuccessAction(EmployeeListViewModel[] Employees);

    public record GetEmployeesFailedAction(string ErrorMessage) : EmployeeFailedAction(ErrorMessage);

}