using Postgrest.Attributes;
using Supabase;

namespace WasmBaseProjectApp.Data.Models;

[Table("employees")]
public class EmployeeModel : SupabaseModel
{
    [PrimaryKey("id", false)] public int Id { get; set; }
    
    [Column("name")] public string? FirstName { get; set; }

    [Column("last_name")] public string? LastName { get; set; }

    [Column("address")] public string? Address { get; set; }

    [Column("note")] public string? Note { get; set; }

    [Column("birth_date")] public DateTime? Birthdate { get; set; }
    
    [Column("status")]public bool Status { get; set; }
}