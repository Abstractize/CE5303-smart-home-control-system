using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Ligth")]
    public class Ligth : Model
    {
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
