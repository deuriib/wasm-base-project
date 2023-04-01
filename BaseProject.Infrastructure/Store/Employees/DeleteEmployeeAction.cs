namespace BaseProject.Infrastructure.Store.Employees;

public sealed record DeleteEmployeeAction(long Id);

public sealed record DeleteEmployeeSuccessAction(long Id);