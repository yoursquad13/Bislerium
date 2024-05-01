using Application.DTOs.Base;
using Application.DTOs.Blog;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BisleriumBlog.Controllers;

[Authorize]
[ApiController]
[Route("api/admnin")]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;
    private readonly IUserService _userService;

    public BlogController(IBlogService blogService, IUserService userService)
    {
        _blogService = blogService;
        _userService = userService;
    }

    [HttpPost("create-blog")]
    public IActionResult CreateBlog(BlogCreateDto blog)
    {
        var result = _blogService.CreateBlog(blog);

        if (result)
        {
            return Ok(new ResponseDto<object>()
            {
                Message = "Blog Created Successfully",
                Data = true,
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1
            });
        }
        else
        {
            return BadRequest(new ResponseDto<bool>()
            {
                Message = "Failed to create blog",
                Data = false,
                Status = "Bad Request",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0
            });
        }
    }

    [HttpPatch("update-blog")]
    public IActionResult UpdateBlog(BlogDetailsDto blog)
    {
        var result = _blogService.UpdateBlog(blog);

        if (result)
        {
            return Ok(new ResponseDto<object>()
            {
                Message = "Blog Updated Successfully",
                Data = true,
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1
            });
        }
        else
        {
            return BadRequest(new ResponseDto<bool>()
            {
                Message = "Failed to update blog",
                Data = false,
                Status = "Bad Request",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0
            });
        }
    }

    [HttpDelete("delete-blog/{blogId:int}")]
    public IActionResult DeleteBlog(int blogId)
    {
        var result = _blogService.DeleteBlog(blogId);

        if (result)
        {
            return Ok(new ResponseDto<object>()
            {
                Message = "Blog Deleted Successfully",
                Data = true,
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1
            });
        }
        else
        {
            return BadRequest(new ResponseDto<bool>()
            {
                Message = "Failed to delete blog",
                Data = false,
                Status = "Bad Request",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0
            });
        }
    }
}
