using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Implementations.Services
{
    public class UserService(IHttpContextAccessor contextAccessor) : IUserService
    {
        public int UserId
        {
            get
            {
                var userIdClaimValue = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

                return int.TryParse(userIdClaimValue, out var userId) ? userId : 0;
            }
        }
    }
}
