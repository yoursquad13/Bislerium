using Application.DTOs.Account;
using Application.DTOs.Base;
using Application.DTOs.Dashboard;
using Application.DTOs.User;
using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Entities.Constants;
using Entities.Models;
using Entities.Utility;
using System.Net;

namespace Infrastructure.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository _genericRepository;

        public AdminService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<UserDetailDto> GetAllUsers()
        {
            var users = _genericRepository.Get<User>().Select(u => new UserDetailDto
            {
                Id = u.Id,
                RoleId = u.RoleId,
                EmailAddress = u.EmailAddress,
                ImageURL = u.ImageURL ?? "",
                Username = u.UserName,
                Name = u.FullName,
                RoleName = _genericRepository.GetById<Role>(u.RoleId).Name
            }).ToList();

            return users;
        }

        public bool RegisterAdmin(RegisterDto register)
        { 
            var existingUser = _genericRepository.Get<User>().FirstOrDefault(u => u.EmailAddress == register.EmailAddress);

            if (existingUser == null)
            {
                var role = _genericRepository.Get<Role>().FirstOrDefault(r => r.Name == "Admin");

                var appUser = new User
                {
                    FullName = register.FullName,
                    EmailAddress = register.EmailAddress,
                    RoleId = role!.Id,
                    Password = Password.HashSecret(Constants.Passwords.AdminPassword),
                    UserName = register.Username,
                    MobileNo = register.MobileNumber,
                    ImageURL = register.ImageURL
                };

                _genericRepository.Insert(appUser);

                return true;
            }
            else
            {
                return false;
            }
        }

        public DashboardDetailsDto GetDashboardDetails(bool allTime = true, int? specificMonth = null)
        {
            IEnumerable<Blog> blogsQuery = _genericRepository.Get<Blog>(x => x.IsActive);

            if (!allTime && specificMonth.HasValue)
            {
                blogsQuery = blogsQuery.Where(x => x.CreatedAt.Month == specificMonth.Value);
            }

            var blogs = blogsQuery.ToList();

            var reactions = _genericRepository.Get<Reaction>(x => x.IsActive);

            var comments = _genericRepository.Get<Comment>(x => x.IsActive);

            var blogDetails = blogs.ToArray();

            var reactionDetails = reactions as Reaction[] ?? reactions.ToArray();

            var commentDetails = comments as Comment[] ?? comments.ToArray();

            var dashboardDetails = new DashboardCount()
            {
                Posts = blogDetails.Length,
                Comments = commentDetails.Length,
                UpVotes = reactionDetails.Count(x => x.ReactionId == 1),
                DownVotes = reactionDetails.Count(x => x.ReactionId == 2),
            };

            var blogDetailsList = new List<BlogDetails>();

            foreach (var blog in blogDetails)
            {
                var upVotes = reactionDetails.Where(x => x.ReactionId == 1 && x.BlogId == blog.Id && x.IsReactedForBlog);

                var downVotes = reactionDetails.Where(x => x.ReactionId == 2 && x.BlogId == blog.Id && x.IsReactedForBlog);

                var commentReactions = commentDetails.Where(x => x.BlogId == blog.Id && x.IsCommentForBlog);

                var commentForComments =
                    commentDetails.Where(x =>
                        commentReactions.Select(z =>
                            z.CommentId).Contains(x.CommentId) && x.IsCommentForComment);

                var popularity = upVotes.Count() * 2 -
                                    downVotes.Count() * 1 +
                                    commentReactions.Count() + commentForComments.Count();

                blogDetailsList.Add(new BlogDetails()
                {
                    BlogId = blog.Id,
                    Blog = blog.Title,
                    BloggerId = blog.CreatedBy,
                    Popularity = popularity
                });
            }

            var bloggerDetailsList = blogDetailsList
                .GroupBy(blog => blog.BloggerId)
                .Select(group => new BloggerDetails
                {
                    BloggerId = group.Key,
                    BloggerName = _genericRepository.GetById<User>(group.Key).FullName,
                    Popularity = group.Sum(blog => blog.Popularity)
                }).ToList();

            var popularBlogs = blogDetailsList
                .OrderByDescending(x => x.Popularity)
                .Take(10).Select(z => new PopularBlog()
                {
                    BlogId = z.BlogId,
                    Blog = z.Blog
                }).ToList();

            var popularBloggers = bloggerDetailsList
                .OrderByDescending(x => x.Popularity)
                .Take(10).Select(z => new PopularBlogger()
                {
                    BloggerId = z.BloggerId,
                    BloggerName = z.BloggerName
                }).ToList();

            var dashboardCounts = new DashboardDetailsDto()
            {
                DashboardCount = dashboardDetails,
                PopularBloggers = popularBloggers,
                PopularBlogs = popularBlogs
            };

           return dashboardCounts;
        }
    }
}
