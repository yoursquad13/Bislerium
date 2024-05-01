using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Base
{
    public class BaseEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get; set; } = default!;

        public bool IsActive { get; set; } = true;

        public int CreatedBy { get; set; } = new();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User? CreatedUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User? UpdatedUser { get; set; }

        [ForeignKey("DeletedBy")]
        public virtual User? DeletedUser { get; set; }
    }
}
