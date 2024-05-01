using Application.DTOs.Blog;

namespace Application.Interfaces.Services
{
    public interface IBlogService
    {
        bool CreateBlog(BlogCreateDto blog);

        bool UpdateBlog(BlogDetailsDto blog);

        bool DeleteBlog(int blogId);
    }
}
