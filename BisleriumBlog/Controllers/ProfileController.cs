using Application.DTOs.Base;
using Application.DTOs.Profile;
using Application.Interfaces.Services;
using Entities.Models;
using Entities.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BisleriumBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [Authorize]
        [HttpGet("profile-details")]
        public IActionResult GetProfileDetails()
        {
            var result = _profileService.GetProfileDetails();

            return Ok(new ResponseDto<ProfileDetailsDto>()
            {
                Message = "Successfully Fetched",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1,
                Status = "Success",
                Data = result
            });
        }

        [Authorize]
        [HttpPatch("update-profile-details")]
        public IActionResult UpdateProfileDetails(ProfileDetailsDto profileDetails)
        {
            var result = _profileService.UpdateProfileDetails(profileDetails);

            return Ok(new ResponseDto<bool>()
            {
                Message = "Successfully Updated",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1,
                Status = "Success",
                Data = result // true or false
            });
        }

        [Authorize]
        [HttpDelete("delete-profile")]
        public IActionResult DeleteProfile()
        {
            var result = _profileService.DeleteProfile();

            return Ok(new ResponseDto<bool>()
            {
                Message = "Successfully Deleted",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1,
                Status = "Success",
                Data = result // true or false
            });
        }

        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword(ChangePasswordDto changePassword)
        {
            var result = _profileService.ChangePassword(changePassword);

            if (result)
            {
                return Ok(new ResponseDto<object>()
                {
                    Message = "Successfully Updated",
                    StatusCode = HttpStatusCode.OK,
                    TotalCount = 1,
                    Status = "Success",
                    Data = true
                });
            }
            else
            {
                return BadRequest(new ResponseDto<object>()
                {
                    Message = "Password not valid",
                    StatusCode = HttpStatusCode.BadRequest,
                    TotalCount = 1,
                    Status = "Invalid",
                    Data = false
                });
            }
        }


        [HttpPost("reset-password")]
        public IActionResult ResetPassword(string emailAddress)
        {
            var result = _profileService.ResetPassword(emailAddress);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
