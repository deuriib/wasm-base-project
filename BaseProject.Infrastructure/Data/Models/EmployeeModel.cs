using Newtonsoft.Json;
using Postgrest.Attributes;
using Postgrest.Models;

namespace BaseProject.Infrastructure.Data.Models;

[Table("employees")]
public class EmployeeModel : BaseModel
{
    [PrimaryKey("id", false)] 
    public int Id { get; set; }
    
    [Column("name")] 
    public string FirstName { get; set; } = default!;
    
    [Column("last_name")] 
    public string LastName { get; set; } = default!;
    
    [Column("email")] 
    public string Email { get; set; } = default!;

    [Column("address", NullValueHandling.Ignore)]
    public string? Address { get; set; } 

    [Column("note", NullValueHandling.Ignore)]
    public string? Note { get; set; } 

    [Column("birth_date")] 
    public DateTime Birthdate { get; set; }
    
    [Column("status")] public bool Status { get; set; }
}