using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.ViewModels;

public record EmployeeListViewModel
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? BirthDate { get; set; }
    
    public EmployeeStatus? Status { get; set; }
}