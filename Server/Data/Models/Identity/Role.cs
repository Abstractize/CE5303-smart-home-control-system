using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Role")]
    public class Role : IdentityRole<Guid>
    {
    }
}
