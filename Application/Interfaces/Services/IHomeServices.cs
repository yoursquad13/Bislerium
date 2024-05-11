
using Application.DTOs.Blog;
using Application.DTOs.Home;
using Entities.Models;

namespace Application.Interfaces.Services
{
    public interface IHomeServices
    {
        List<BlogPostDetailsNewDto> GetHomePageBlogs();

        Blog[] GetActiveBlogs();

        Blog[] GetActiveBlogsByUserId();

        List<BlogPostDetailsDto> GetBloggersBlogs();

        BlogPostDetailsNewDto GetBlogDetails(int blogId);

        List<BlogLogDto> GetBlogLog(int blogId);

        bool UpVoteDownVoteBlog(int blogId, int reactionId);

        bool UpVoteDownVoteComment(int commentId, int reactionId);

        bool CommentForBlog(int blogId, string commentText);

        bool CommentForComment(int commentId, string commentText);

        bool DeleteComment(int commentId);

        bool EditComment(int commentId, string commentText);

        bool RemoveBlogVote(int blogId);

        bool RemoveCommentVote(int commentId);

        List<CommentLogDto> GetCommentLog(int commentId);
    }
}
