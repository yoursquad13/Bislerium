using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? MobileNo { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string? ImageURL { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
