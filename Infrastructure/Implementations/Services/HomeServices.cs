using Application.DTOs.Base;
using Application.DTOs.Blog;
using Application.DTOs.Home;
using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Entities.Models;
using Entities.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Infrastructure.Implementations.Services
{
    public class HomeServices : IHomeServices
    {
        private readonly IUserService _userService;
        private readonly IGenericRepository _genericRepository;

        public HomeServices(IUserService userService, IGenericRepository genericRepository)
        {
            _userService = userService;
            _genericRepository = genericRepository;
        }

        public Blog[] GetActiveBlogs()
        {
            var blogs = _genericRepository.Get<Blog>(x => x.IsActive);

            var blogDetails = blogs as Blog[] ?? blogs.ToArray();

            return blogDetails;
        }

        public Blog[] GetActiveBlogsByUserId()
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogs = _genericRepository.Get<Blog>(x => x.IsActive && x.CreatedBy == user.Id);

            var blogDetails = blogs as Blog[] ?? blogs.ToArray();

            return blogDetails;
        }

        public List<BlogPostDetailsNewDto> GetHomePageBlogs()
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogs = _genericRepository.Get<Blog>(x => x.IsActive);

            var blogDetails = blogs as Blog[] ?? blogs.ToArray();

            var blogPostDetails = new List<BlogPostDetailsNewDto>();

            foreach (var blog in blogDetails)
            {

                var userDetail = _genericRepository.GetById<User>(blog.CreatedBy);

                var reactions = _genericRepository.Get<Reaction>(x => x.BlogId == blog.Id && x.IsReactedForBlog && x.IsActive);

                var comments = _genericRepository.Get<Comment>(x => x.BlogId == blog.Id && x.IsActive);

                var reactionDetails = reactions as Reaction[] ?? reactions.ToArray();

                var commentDetails = comments as Comment[] ?? comments.ToArray();

                var upVotes = reactionDetails.Where(x => x.ReactionId == 1 && x.BlogId == blog.Id && x.IsReactedForBlog);

                var downVotes = reactionDetails.Where(x => x.ReactionId == 2 && x.BlogId == blog.Id && x.IsReactedForBlog);

                var commentForComments =
                    commentDetails.Where(x =>
                        commentDetails.Select(z =>
                            z.CommentId).Contains(x.CommentId) && x.IsCommentForComment);

                var popularity = upVotes.Count() * 2 -
                                 downVotes.Count() * 1 +
                                 commentDetails.Count() + commentForComments.Count();

                blogPostDetails.Add(new BlogPostDetailsNewDto()
                {
                    Author = userDetail.FullName,
                                    AuthorId = userDetail.Id,
                    AuthorImage = userDetail.ImageURL,
                    BlogId = blog.Id,
                    Title = blog.Title,
                    Body = blog.Body,
                    UpVotes = reactionDetails.Count(x => x.ReactionId == 1),
                    DownVotes = reactionDetails.Count(x => x.ReactionId == 2),
                    IsUpVotedByUser = user != null && reactionDetails.Any(x => x.ReactionId == 1 && x.CreatedBy == user.Id),
                    IsDownVotedByUser = user != null && reactionDetails.Any(x => x.ReactionId == 2 && x.CreatedBy == user.Id),
                    IsEdited = blog.LastModifiedAt != null,
                    CreatedAt = blog.CreatedAt,
                    PopularityPoints = popularity,
                    Images = _genericRepository.Get<BlogImage>(x => x.BlogId == blog.Id && x.IsActive).Select(x => x.ImageURL).ToList(),
                    UploadedTimePeriod = DateTime.Now.Hour - blog.CreatedAt.Hour < 24 ? $"{(int)(DateTime.Now - blog.CreatedAt).TotalHours} hours ago" : blog.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                    Comments = _genericRepository.Get<Comment>(x => x.BlogId == blog.Id && x.IsActive && x.IsCommentForBlog).Select(x => new PostComments()
                    {
                        Comment = x.Text,
                        UpVotes = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Count(z => z.ReactionId == 1),
                        DownVotes = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Count(z => z.ReactionId == 2),
                        IsUpVotedByUser = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Any(z => z.ReactionId == 1 && z.CreatedBy == user.Id),
                        IsDownVotedByUser = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Any(z => z.ReactionId == 2 && z.CreatedBy == user.Id),
                        CommentId = x.Id,
                        CommentedBy = _genericRepository.GetById<User>(x.CreatedBy).FullName,
                        ImageUrl = _genericRepository.GetById<User>(x.CreatedBy).ImageURL ?? "sample-profile.png",
                        IsUpdated = x.LastModifiedAt != null,
                        CommentedTimePeriod = DateTime.Now.Hour - x.CreatedAt.Hour < 24 ? $"{(int)(DateTime.Now - x.CreatedAt).TotalHours} hours ago" : x.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                    }).Take(1).ToList()
                });
            }

            return blogPostDetails;
        }

        public List<BlogPostDetailsDto> GetBloggersBlogs()
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogs = _genericRepository.Get<Blog>(x => x.IsActive && x.CreatedBy == user.Id);

            var blogDetails = blogs as Blog[] ?? blogs.ToArray();

            var blogPostDetails = new List<BlogPostDetailsDto>();

            foreach (var blog in blogDetails)
            {
                var reactions = _genericRepository.Get<Reaction>(x => x.BlogId == blog.Id && x.IsReactedForBlog && x.IsActive);

                var comments = _genericRepository.Get<Comment>(x => x.BlogId == blog.Id && x.IsActive);

                var reactionDetails = reactions as Reaction[] ?? reactions.ToArray();

                var commentDetails = comments as Comment[] ?? comments.ToArray();

                var upVotes = reactionDetails.Where(x => x.ReactionId == 1 && x.BlogId == blog.Id && x.IsReactedForBlog);

                var downVotes = reactionDetails.Where(x => x.ReactionId == 2 && x.BlogId == blog.Id && x.IsReactedForBlog);

                var commentForComments =
                    commentDetails.Where(x =>
                        commentDetails.Select(z =>
                            z.CommentId).Contains(x.CommentId) && x.IsCommentForComment);

                var popularity = upVotes.Count() * 2 -
                                 downVotes.Count() * 1 +
                                 commentDetails.Count() + commentForComments.Count();

                blogPostDetails.Add(new BlogPostDetailsDto()
                {
                    BlogId = blog.Id,
                    Title = blog.Title,
                    Body = blog.Body,
                    UpVotes = reactionDetails.Count(x => x.ReactionId == 1),
                    DownVotes = reactionDetails.Count(x => x.ReactionId == 2),
                    IsUpVotedByUser = reactionDetails.Any(x => x.ReactionId == 1 && x.CreatedBy == user.Id),
                    IsDownVotedByUser = reactionDetails.Any(x => x.ReactionId == 2 && x.CreatedBy == user.Id),
                    IsEdited = blog.LastModifiedAt != null,
                    CreatedAt = blog.CreatedAt,
                    PopularityPoints = popularity,
                    Images = _genericRepository.Get<BlogImage>(x => x.BlogId == blog.Id && x.IsActive).Select(x => x.ImageURL).ToList(),
                    UploadedTimePeriod = DateTime.Now.Hour - blog.CreatedAt.Hour < 24 ? $"{(int)(DateTime.Now - blog.CreatedAt).TotalHours} hours ago" : blog.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                    Comments = _genericRepository.Get<Comment>(x => x.BlogId == blog.Id && x.IsActive && x.IsCommentForBlog).Select(x => new PostComments()
                    {
                        Comment = x.Text,
                        UpVotes = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Count(z => z.ReactionId == 1),
                        DownVotes = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Count(z => z.ReactionId == 2),
                        IsUpVotedByUser = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Any(z => z.ReactionId == 1 && z.CreatedBy == user.Id),
                        IsDownVotedByUser = _genericRepository.Get<Reaction>(z => z.BlogId == blog.Id && z.IsReactedForComment && x.IsActive).Any(z => z.ReactionId == 2 && z.CreatedBy == user.Id),
                        CommentId = x.Id,
                        CommentedBy = _genericRepository.GetById<User>(x.CreatedBy).FullName,
                        ImageUrl = _genericRepository.GetById<User>(x.CreatedBy).ImageURL ?? "sample-profile.png",
                        IsUpdated = x.LastModifiedAt != null,
                        CommentedTimePeriod = DateTime.Now.Hour - x.CreatedAt.Hour < 24 ? $"{(int)(DateTime.Now - x.CreatedAt).TotalHours} hours ago" : x.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                    }).Take(1).ToList()
                });
            }

            return blogPostDetails;

        }

        public BlogPostDetailsNewDto GetBlogDetails(int blogId)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blog = _genericRepository.GetById<Blog>(blogId);

            var userDetail = _genericRepository.GetById<User>(blog.CreatedBy);

            if (blog == null)
            {
                return null;
            }   

            var reactions = _genericRepository.Get<Reaction>(x => x.BlogId == blog.Id && x.IsReactedForBlog && x.IsActive);

            var comments = _genericRepository.Get<Comment>(x => x.BlogId == blog.Id && x.IsActive);

            var reactionDetails = reactions as Reaction[] ?? reactions.ToArray();

            var commentDetails = comments as Comment[] ?? comments.ToArray();

            var upVotes = reactionDetails.Where(x => x.ReactionId == 1 && x.BlogId == blog.Id && x.IsReactedForBlog);

            var downVotes = reactionDetails.Where(x => x.ReactionId == 2 && x.BlogId == blog.Id && x.IsReactedForBlog);

            var commentForComments =
                commentDetails.Where(x =>
                    commentDetails.Select(z =>
                        z.CommentId).Contains(x.CommentId) && x.IsCommentForComment);

            var popularity = upVotes.Count() * 2 -
                             downVotes.Count() * 1 +
                             commentDetails.Count() + commentForComments.Count();

            var blogDetails = new BlogPostDetailsNewDto()
            {
                Author = userDetail.FullName,
                AuthorId = userDetail.Id,
                AuthorImage = userDetail.ImageURL,
                BlogId = blog.Id,
                Title = blog.Title,
                Body = blog.Body,
                UpVotes = reactionDetails.Count(x => x.ReactionId == 1),
                DownVotes = reactionDetails.Count(x => x.ReactionId == 2),
                IsUpVotedByUser = user != null && reactionDetails.Any(x => x.ReactionId == 1 && x.CreatedBy == user.Id),
                IsDownVotedByUser = user != null && reactionDetails.Any(x => x.ReactionId == 2 && x.CreatedBy == user.Id),
                IsEdited = blog.LastModifiedAt != null,
                CreatedAt = blog.CreatedAt,
                PopularityPoints = popularity,
                Images = _genericRepository.Get<BlogImage>(x => x.BlogId == blog.Id && x.IsActive).Select(x => x.ImageURL).ToList(),
                UploadedTimePeriod = DateTime.Now.Hour - blog.CreatedAt.Hour < 24 ? $"{(int)(DateTime.Now - blog.CreatedAt).TotalHours} hours ago" : blog.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                Comments = GetCommentsRecursive(blog.Id, false, true)
            };

            return blogDetails;
        }

        public bool UpVoteDownVoteBlog(int blogId, int reactionId)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blog = _genericRepository.GetById<Blog>(blogId);

            var existingReaction =
                _genericRepository.Get<Reaction>(x => x.CreatedBy == user.Id &&
                    x.ReactionId != 3 && x.IsReactedForBlog);

            var existingReactionDetails = existingReaction as Reaction[] ?? existingReaction.ToArray();

            if (existingReactionDetails.Any())
            {
                _genericRepository.RemoveMultipleEntity(existingReactionDetails);
            }

            var reaction = new Reaction()
            {
                ReactionId = reactionId,
                BlogId = blog.Id,
                CommentId = null,
                IsReactedForBlog = true,
                IsReactedForComment = false,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
                IsActive = true,
            };

            _genericRepository.Insert(reaction);

            return true;
        }

        public bool UpVoteDownVoteComment(int commentId, int reactionId)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var comment = _genericRepository.GetById<Comment>(commentId);

            var existingReaction =
                _genericRepository.Get<Reaction>(x => x.CreatedBy == user.Id &&
                                                      x.ReactionId != 3 && x.IsReactedForComment);

            var existingReactionDetails = existingReaction as Reaction[] ?? existingReaction.ToArray();

            if (existingReactionDetails.Any())
            {
                _genericRepository.RemoveMultipleEntity(existingReactionDetails);
            }

            var reaction = new Reaction()
            {
                ReactionId = reactionId,
                BlogId = null,
                CommentId = comment.Id,
                IsReactedForBlog = false,
                IsReactedForComment = true,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
                IsActive = true,
            };

            _genericRepository.Insert(reaction);

            return true;
        }

        public bool CommentForBlog(int blogId, string commentText)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blog = _genericRepository.GetById<Blog>(blogId);

            var comment = new Comment()
            {
                BlogId = blog.Id,
                CommentId = null,
                Text = commentText,
                IsCommentForBlog = true,
                IsCommentForComment = false,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
            };

            _genericRepository.Insert(comment);

            return true;
        }

        public bool CommentForComment(int commentId, string commentText)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var commentModel = _genericRepository.GetById<Comment>(commentId);

            var comment = new Comment()
            {
                BlogId = null,
                CommentId = commentModel.Id,
                Text = commentText,
                IsCommentForBlog = false,
                IsCommentForComment = true,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
            };

            _genericRepository.Insert(comment);

            return true;
        }

        public bool DeleteComment(int commentId)
        {
            var comment = _genericRepository.GetById<Comment>(commentId);

            comment.IsActive = false;

            _genericRepository.Update(comment);

            return true;
        }

        public bool RemoveBlogVote(int blogId)
        {
            var blog = _genericRepository.GetById<Blog>(blogId);

            var blogReactions = _genericRepository.Get<Reaction>(x => x.BlogId == blog.Id
                                                                         && x.IsReactedForBlog);

            foreach (var blogReaction in blogReactions)
            {
                blogReaction.IsActive = false;

                _genericRepository.Update(blogReaction);
            }
            return true;
        }

        public bool RemoveCommentVote(int commentId)
        {
            var comment = _genericRepository.GetById<Comment>(commentId);

            var commentReactions = _genericRepository.Get<Reaction>(x => x.CommentId == comment.Id
                                                                         && x.IsReactedForComment);

            foreach (var commentReaction in commentReactions)
            {
                commentReaction.IsActive = false;

                _genericRepository.Update(commentReaction);
            }
            return true;
        }

        private List<PostComments> GetCommentsRecursive(int blogId, bool isForComment, bool isForBlog, int? parentId = null)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var comments =
                _genericRepository.Get<Comment>(x => x.BlogId == blogId && x.IsActive &&
                    x.IsCommentForBlog == isForBlog && x.IsCommentForComment == isForComment && x.CommentId == parentId)
                        .Select(x => new PostComments()
                        {
                            Comment = x.Text,
                            CreatedAt = x.CreatedAt,
                            UpVotes = _genericRepository.Get<Reaction>(z => z.CommentId == x.Id && z.IsReactedForComment).Count(z => z.ReactionId == 1 && z.CommentId == x.Id),
                            DownVotes = _genericRepository.Get<Reaction>(z => z.CommentId == x.Id && z.IsReactedForComment).Count(z => z.ReactionId == 2 && z.CommentId == x.Id),
                            IsUpVotedByUser = user != null && _genericRepository.Get<Reaction>(z => z.CommentId == x.Id && z.IsReactedForComment).Any(z => z.ReactionId == 1 && z.CreatedBy == user.Id && z.CommentId == x.Id),
                            IsDownVotedByUser = user != null && _genericRepository.Get<Reaction>(z => z.CommentId == x.Id && z.IsReactedForComment).Any(z => z.ReactionId == 2 && z.CreatedBy == user.Id && z.CommentId == x.Id),
                            CommentId = x.Id,
                            CommentedBy = _genericRepository.GetById<User>(x.CreatedBy).FullName,
                            ImageUrl = _genericRepository.GetById<User>(x.CreatedBy).ImageURL ?? "sample-profile.png",
                            IsUpdated = x.LastModifiedAt != null,
                            CommentedTimePeriod = DateTime.Now.Hour - x.CreatedAt.Hour < 24 ? $"{(int)(DateTime.Now - x.CreatedAt).TotalHours} hours ago" : x.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                            Comments = GetCommentsRecursive(blogId, true, false, x.Id)
                        }).OrderByDescending(x => x.CreatedAt).ToList();

            return comments;
        }

        public bool EditComment(int commentId, string commentText)
        {
            var comment = _genericRepository.GetById<Comment>(commentId);

            if (comment == null)
            {
                return false;
            }

            var commentLog = new CommentLog()
            {
                CommentId = comment.Id,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt,
                CreatedBy = comment.CreatedBy,
                IsActive = false
            };

            _genericRepository.Insert(commentLog);

            comment.Text = commentText;
    
            comment.LastModifiedAt = DateTime.Now;
    
            _genericRepository.Update(comment);
    
            return true;
        }

        public List<CommentLogDto> GetCommentLog(int commentId)
        {
            var commentLog = _genericRepository.Get<CommentLog>(x => x.CommentId == commentId);

            if (commentLog == null)
            {
                return null;
            }

            var commentLogDetails = commentLog.Select(x => new CommentLogDto()
            {
                CommentId = x.CommentId,
                Text = x.Text,
                CreatedBy = _genericRepository.GetById<User>(x.CreatedBy).FullName,
                CommentedAt = x.CreatedAt
            }).ToList();

            return commentLogDetails;
            
        }

        public List<BlogLogDto> GetBlogLog(int blogId)
        {
            var blogLog = _genericRepository.Get<BlogLog>(x => x.BlogId == blogId);

            if (blogLog == null)
            {
                return null;
            }

            var blogLogDetails = blogLog.Select(x => new BlogLogDto()
            {
                BlogId = x.BlogId,
                Title = x.Title,
                Body = x.Body,
                CreatedBy = _genericRepository.GetById<User>(x.CreatedBy).FullName,
                CreatedAt = x.CreatedAt
            }).ToList();

            return blogLogDetails;
        }
    }
}
