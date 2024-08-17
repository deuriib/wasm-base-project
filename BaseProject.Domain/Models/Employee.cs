using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BaseProject.Domain.Models;

[Table("employees")]
public sealed class Employee : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; init; } = default!;

    [Column("last_name")]
    public string LastName { get; init; } = default!;
    [Column("email")]
    public string Email { get; init; } = default!;

    [Column("birth_date")]
    public DateTime Birthdate { get; init; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("address")]
    public string? Address { get; init; } = default!;

    [Column("note")]
    public string? Note { get; init; } = default!;
}