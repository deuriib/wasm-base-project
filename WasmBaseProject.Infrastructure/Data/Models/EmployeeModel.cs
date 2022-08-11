using Newtonsoft.Json;
using Postgrest.Attributes;

namespace WasmBaseProject.Infrastructure.Data.Models;

[Table("employees")]
public class EmployeeModel : Supabase.SupabaseModel
{
    [PrimaryKey("id", false)] public int Id { get; set; }
    [Column("name")] public string FirstName { get; set; } = string.Empty;
    [Column("last_name")] public string LastName { get; set; } = string.Empty;
    [Column("email")] public string Email { get; set; } = string.Empty;

    [Column("address", NullValueHandling.Ignore)]
    public string? Address { get; set; }

    [Column("note", NullValueHandling.Ignore)]
    public string? Note { get; set; }

    [Column("birth_date")] public DateTime? Birthdate { get; set; }
    [Column("status")] public bool Status { get; set; }
}