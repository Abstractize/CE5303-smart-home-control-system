using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Room")]
    public class Room : Model
    {
        [Required]
        public String Name { get; set; }
        public Ligth Ligth { get; set; }
        public List<Door> Doors { get; set; }
    }
}
