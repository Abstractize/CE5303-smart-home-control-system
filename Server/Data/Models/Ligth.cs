using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Light")]
    public class Light : Model
    {
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
