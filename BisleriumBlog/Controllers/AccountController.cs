using Application.DTOs.Account;
using Application.DTOs.Base;
using Application.Interfaces.Services;
using Entities.Constants;
using Entities.Models;
using Entities.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace BisleriumBlog.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly JWTSettings _jwtSettings;

        public AccountController(IAccountService accountService, IOptions<JWTSettings> jwtSettings)
        {
            _accountService = accountService;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginRequest)
        {
            var user = _accountService.GetUserByEmail(loginRequest.EmailAddress);

            if (user == null)
            {
                return NotFound(new ResponseDto<bool>()
                {
                    Message = "User not found",
                    Data = false,
                    Status = "Not Found",
                    StatusCode = HttpStatusCode.NotFound,
                    TotalCount = 0
                });
            }

            var isPasswordValid = Password.VerifyHash(loginRequest.Password, user.Password);

            if (!isPasswordValid)
            {
                return Unauthorized(new ResponseDto<bool>()
                {
                    Message = "Password incorrect",
                    Data = false,
                    Status = "Unauthorized",
                    StatusCode = HttpStatusCode.Unauthorized,
                    TotalCount = 0
                });
            }

            var role = _accountService.GetRoleById(user.RoleId);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, (user.Id.ToString() ?? null) ?? string.Empty),
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Email, user.EmailAddress),
                new(ClaimTypes.Role, role.Name ?? ""),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var symmetricSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSigningKey, SecurityAlgorithms.HmacSha256);

            var expirationTime = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtSettings.DurationInMinutes));

            var accessToken = new JwtSecurityToken(
               _jwtSettings.Issuer,
               _jwtSettings.Audience,
               claims: authClaims,
               signingCredentials: signingCredentials,
               expires: expirationTime
            );

            var userDetails = new UserDto()
            {
                Id = user.Id,
                Name = user.FullName,
                Username = user.UserName,
                EmailAddress = user.EmailAddress,
                RoleId = role.Id,
                Role = role.Name ?? "",
                Token = new JwtSecurityTokenHandler().WriteToken(accessToken)
            };

            return Ok(new ResponseDto<UserDto>()
            {
                Message = "Successfully authenticated",
                Data = userDetails,
                Status = "Success",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1
            });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto register)
        {
            var existingUser = _accountService.GetExistingUser(register.EmailAddress, register.Username);

            if (existingUser == null)
            {
                var role = _accountService.GetRoleByName(Constants.Roles.Blogger);

                var appUser = new User()
                {
                    FullName = register.FullName,
                    EmailAddress = register.EmailAddress,
                    RoleId = role!.Id,
                    Password = Password.HashSecret(register.Password),
                    UserName = register.Username,
                    MobileNo = register.MobileNumber,
                    ImageURL = register.ImageURL
                };

                _accountService.InsertUser(appUser);

                return Ok(new ResponseDto<object>()
                {
                    Message = "Successfully registered",
                    Data = true,
                    Status = "Success",
                    StatusCode = HttpStatusCode.OK,
                    TotalCount = 1
                });
            }

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
