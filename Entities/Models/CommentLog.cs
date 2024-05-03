using Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CommentLog : BaseEntity<int>
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment? Comment { get; set; }
    }
}
