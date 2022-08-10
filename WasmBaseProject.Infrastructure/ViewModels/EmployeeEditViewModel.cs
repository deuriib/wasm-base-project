namespace WasmBaseProject.Infrastructure.ViewModels;

public record EmployeeEditViewModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Note { get; set; }
    public DateTime? Birthdate { get; set; }
}