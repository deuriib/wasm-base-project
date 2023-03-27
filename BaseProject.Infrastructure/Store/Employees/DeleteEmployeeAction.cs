namespace BaseProject.Infrastructure.Store.Employees;

public record DeleteEmployeeAction(int? Id);

public record DeleteEmployeeSuccessAction(int? Id);