using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

[Table("User")]
public class User : IdentityUser<Guid>
{
    [Required]
    public String Name { get; set; }
}

