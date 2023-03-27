using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees
{
    public record GetOneEmployeeAction(int? Id);
    public record GetOneEmployeeSuccessAction(EmployeeEditViewModel? Employee);
    public record GetOneEmployeeFailedAction(string? ErrorMessage): EmployeeFailedAction(ErrorMessage);
}
