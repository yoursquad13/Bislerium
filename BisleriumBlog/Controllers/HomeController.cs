using Application.DTOs.Base;
using Application.DTOs.Home;
using Application.Interfaces.Services;
using Entities.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BisleriumBlog.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices _homeServices;

        public HomeController(IHomeServices homeServices)
        {
            _homeServices = homeServices;
        }

        [HttpGet("home-page-blogs")]
        public IActionResult GetHomePageBlogs(int pageNumber, int pageSize, string? sortBy = null)
        {
            var blogPostDetails = _homeServices.GetHomePageBlogs();

            var blogDetails = _homeServices.GetActiveBlogs();

            switch (sortBy)
            {
                case null:
                    blogPostDetails = blogPostDetails.OrderByDescending(x => x.CreatedAt).ToList();
                    break;
                case "Popularity":
                    blogPostDetails = blogPostDetails.OrderByDescending(x => x.PopularityPoints).ToList();
                    break;
                case "Recency":
                    blogPostDetails = blogPostDetails.OrderByDescending(x => x.CreatedAt).ToList();
                    break;
                default:
                    blogPostDetails.Shuffle();
                    break;
            }

            var result = new ResponseDto<List<BlogPostDetailsNewDto>>()
            {
                Message = "Success",
                Data = blogPostDetails.Skip(pageNumber - 1).Take(pageSize).ToList(),
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = blogDetails.Count()
            };

            return Ok(result);
        }


        [HttpGet("my-blogs")]
        public IActionResult GetBloggersBlogs(int pageNumber, int pageSize, string? sortBy = null)
        {
            var blogPostDetails = _homeServices.GetBloggersBlogs();

            var blogDetails = _homeServices.GetActiveBlogsByUserId();

            switch (sortBy)
            {
                case null:
                    blogPostDetails = blogPostDetails.OrderByDescending(x => x.CreatedAt).ToList();
                    break;
                case "Popularity":
                    blogPostDetails = blogPostDetails.OrderByDescending(x => x.PopularityPoints).ToList();
                    break;
                case "Recency":
                    blogPostDetails = blogPostDetails.OrderByDescending(x => x.CreatedAt).ToList();
                    break;
                default:
                    blogPostDetails.Shuffle();
                    break;
            }

            var result = new ResponseDto<List<BlogPostDetailsDto>>()
            {
                Message = "Success",
                Data = blogPostDetails.Skip(pageNumber - 1).Take(pageSize).ToList(),
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = blogDetails.Count()
            };

            return Ok(result);
        }

        [HttpGet("blogs-details/{blogId:int}")]
        public IActionResult GetBlogDetails(int blogId)
        {
            var blogDetails = _homeServices.GetBlogDetails(blogId);

            if(blogDetails == null)
            {
                return NotFound(new ResponseDto<object>()
                {
                    Message = "Blog not found",
                    Data = false,
                    Status = "Not Found",
                    StatusCode = HttpStatusCode.NotFound,
                    TotalCount = 0
                });
            }

            var result = new ResponseDto<BlogPostDetailsNewDto>()
            {
                Message = "Success",
                Data = blogDetails,
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1
            };

            return Ok(result);
        }

        [HttpPost("upvote-downvote-blog")]
        public IActionResult UpVoteDownVoteBlog(int blogId, int reactionId)
        {
            var result = _homeServices.UpVoteDownVoteBlog(blogId, reactionId);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

        [HttpPost("upvote-downvote-comment")]
        public IActionResult UpVoteDownVoteComment(int commentId, int reactionId)
        {
            var result = _homeServices.UpVoteDownVoteComment(commentId, reactionId);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

        [HttpPost("comment-for-blog")]
        public IActionResult CommentForBlog(int blogId, string commentText)
        {
            var result = _homeServices.CommentForBlog(blogId, commentText);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

        [HttpPost("comment-for-comment")]
        public IActionResult CommentForComment(int commentId, string commentText)
        {
            var result = _homeServices.CommentForComment(commentId, commentText);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            }); 
        }

        [HttpDelete("delete-comment/{commentId:int}")]
        public IActionResult DeleteComment(int commentId)
        {
            var result = _homeServices.DeleteComment(commentId);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

        [HttpDelete("remove-blog-reaction/{blogId:int}")]
        public IActionResult RemoveBlogVote(int blogId)
        {
            var result = _homeServices.RemoveBlogVote(blogId);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

        [HttpDelete("remove-comment-reaction/{commentId:int}")]
        public IActionResult RemoveCommentVote(int commentId)
        {
            var result = _homeServices.RemoveCommentVote(commentId);

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

        [HttpPatch("edit-comment/{commentId:int}")]
        public IActionResult EditComment(int commentId, string commentText)
        {
            var result = _homeServices.EditComment(commentId, commentText);

            if(!result)
            {
                return NotFound(new ResponseDto<object>()
                {
                    Message = "Comment not found",
                    Data = false,
                    Status = "Not Found",
                    StatusCode = HttpStatusCode.NotFound,
                    TotalCount = 0
                });
            }

            return Ok(new ResponseDto<object>()
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 0,
                Status = "Success",
                Data = result //true or false
            });
        }

    }
}
