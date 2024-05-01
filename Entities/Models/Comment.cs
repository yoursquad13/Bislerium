using Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Comment : BaseEntity<int>
    {
        public string Text { get; set; }

        public bool IsCommentForBlog { get; set; }

        public bool IsCommentForComment { get; set; }

        public int? BlogId { get; set; }

        public int? CommentId { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog? Blog { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment? Comments { get; set; }
    }
}
