using Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Notification : BaseEntity<int>
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsSeen { get; set; }

        public int BlogId { get; set; }

        [ForeignKey("SenderId")]
        public virtual User? Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual User? Receiver { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog? Blog { get; set; }
    }
}
