using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Photo")]
    public class Photo : Model
    {
        public String FileName { get; set; }
        public Byte[] Data { get; set; }
    }
}
