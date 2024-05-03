
namespace Application.DTOs.Home
{
    public class BlogPostDetailsDto : UserActions
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string UploadedTimePeriod { get; set; }

        public bool IsEdited { get; set; }

        public int PopularityPoints { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<string> Images { get; set; }

        public List<PostComments> Comments { get; set; }
    }

    public class PostComments : UserActions
    {
        public int CommentId { get; set; }

        public string ImageUrl { get; set; }

        public string CommentedBy { get; set; }

        public string CommentedTimePeriod { get; set; }

        public string Comment { get; set; }

        public bool IsUpdated { get; set; }

        public List<PostComments> Comments { get; set; }
    }

    public class UserActions
    {
        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public bool IsUpVotedByUser { get; set; }

        public bool IsDownVotedByUser { get; set; }
    }
}
