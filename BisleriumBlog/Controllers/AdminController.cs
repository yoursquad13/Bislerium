using Application.DTOs.Account;
using Application.DTOs.Base;
using Application.DTOs.User;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BisleriumBlog.Controllers;

[Authorize]
[ApiController]
[Route("api/admnin")]
public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("get-all-users")]
    public IActionResult GetAllUsers()
    {
        var users = _adminService.GetAllUsers();

        return Ok(new ResponseDto<List<UserDetailDto>>()
        {
            Message = "Successfully Retrieved",
            Data = users,
            Status = "Success",
            StatusCode = HttpStatusCode.OK,
            TotalCount = 1
        });
    }

    [HttpPost("register-admin")]
    public IActionResult RegisterAdmin(RegisterDto register)
    {
        var result = _adminService.RegisterAdmin(register);

        if (result)
        {
            return Ok(new ResponseDto<object>()
            {
                Message = "Admin Registered Successfully",
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
                Message = "Existing user with the same user name or email address",
                Data = false,
                Status = "Bad Request",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0
            });
        }
    }
}
