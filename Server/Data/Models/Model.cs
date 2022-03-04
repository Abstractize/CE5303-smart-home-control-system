using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public abstract class Model : Model<Guid> { }
    public abstract class Model<ID> where ID : IEquatable<ID>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ID Id { get; set; }
        public DateTime? RemovedDate { get; set; } = null;
    }
}