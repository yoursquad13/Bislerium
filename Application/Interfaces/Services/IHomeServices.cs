
using Application.DTOs.Home;
using Entities.Models;

namespace Application.Interfaces.Services
{
    public interface IHomeServices
    {
        List<BlogPostDetailsDto> GetHomePageBlogs();

        Blog[] GetActiveBlogs();

        Blog[] GetActiveBlogsByUserId();

        List<BlogPostDetailsDto> GetBloggersBlogs();

        BlogPostDetailsDto GetBlogDetails(int blogId);

        bool UpVoteDownVoteBlog(int blogId, int reactionId);

        bool UpVoteDownVoteComment(int commentId, int reactionId);

        bool CommentForBlog(int blogId, string commentText);

        bool CommentForComment(int commentId, string commentText);

        bool DeleteComment(int commentId);

        bool RemoveBlogVote(int blogId);

        bool RemoveCommentVote(int commentId);
    }
}
