namespace WasmBaseProjectApp.ViewModels;

public record EmployeeListViewModel
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? BirthDate { get; set; }
    
    public bool Status { get; set; }
}