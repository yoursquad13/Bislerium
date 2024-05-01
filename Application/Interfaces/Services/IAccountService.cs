using Application.DTOs.Account;
using Application.DTOs.Base;
using Entities.Models;

namespace Application.Interfaces.Services
{
    public interface IAccountService
    {
        User GetUserByEmail(string email);

        Role GetRoleById(int roleId);

        User GetExistingUser(string emailAddress, string username);

        Role GetRoleByName(string roleName);

        void InsertUser(User user);
    }
}
