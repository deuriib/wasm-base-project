using BaseProject.Domain.Enums;

namespace BaseProject.Infrastructure.ViewModels;

public record EmployeeListViewModel(int Id, string FullName, string Email, EmployeeStatus Status, string Birthdate);