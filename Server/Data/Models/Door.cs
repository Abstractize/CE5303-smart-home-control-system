using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Door")]
    public class Door : Model
    {
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
