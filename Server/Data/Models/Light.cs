using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Light")]
    public class Light : Model
    {
        public int Pin { get; set; }
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
