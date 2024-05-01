using Application.DTOs.Blog;
using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Entities.Models;

namespace Infrastructure.Implementations.Services
{
    public class BlogService : IBlogService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IUserService _userService;

        public BlogService(IGenericRepository genericRepository, IUserService userService)
        {
            _genericRepository = genericRepository;
            _userService = userService;
        }

        public bool CreateBlog (BlogCreateDto blog)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogModel = new Blog()
            {
                Title = blog.Title,
                Body = blog.Body,
                Location = blog.Location,
                Reaction = blog.Reaction,
                BlogImages = blog.Images.Select(x => new BlogImage()
                {
                    ImageURL = x
                }).ToList(),
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
            };

            _genericRepository.Insert(blogModel);

            return true;
        }

        public bool UpdateBlog (BlogDetailsDto blog)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogModel = _genericRepository.GetById<Blog>(blog.Id);

            var blogLog = new BlogLog()
            {
                BlogId = blogModel.Id,
                Title = blogModel.Title,
                Location = blogModel.Location,
                Reaction = blogModel.Reaction,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
                Body = blogModel.Body,
                IsActive = false
            };

            _genericRepository.Insert(blogLog);

            blogModel.Title = blog.Title;
            blogModel.Body = blog.Body;
            blogModel.Location = blog.Location;
            blogModel.Reaction = blog.Reaction;

            blogModel.LastModifiedAt = DateTime.Now;
            blogModel.LastModifiedBy = user.Id;

            _genericRepository.Update(blogModel);

            return true;
        }

        public bool DeleteBlog(int blogId)
        { 
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogModel = _genericRepository.GetById<Blog>(blogId);

            blogModel.IsActive = false;
            blogModel.DeletedAt = DateTime.Now;
            blogModel.DeletedBy = user.Id;

            _genericRepository.Update(blogModel);

            return true;
        }
    }
}
