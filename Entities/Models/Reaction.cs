using Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Reaction : BaseEntity<int>
    {
        public int ReactionId { get; set; }               // 1 is for Upvote, 2 is for Downvote, 3 is for Comment

        public bool IsReactedForBlog { get; set; }

        public bool IsReactedForComment { get; set; }

        public int? BlogId { get; set; }

        public int? CommentId { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog? Blog { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment? Comment { get; set; }
    }
}
