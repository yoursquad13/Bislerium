using Application.DTOs.Account;
using Application.DTOs.User;

namespace Application.Interfaces.Services
{
    public interface IAdminService
    {
        List<UserDetailDto> GetAllUsers();

        bool RegisterAdmin(RegisterDto register);
    }
}
