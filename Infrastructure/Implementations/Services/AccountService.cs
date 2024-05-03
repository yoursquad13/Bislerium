using Application.DTOs.Account;
using Application.DTOs.Base;
using Application.DTOs.User;
using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Entities.Models;
using Entities.Utility;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Implementations.Services
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository _genericRepository;

        public AccountService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email address is empty or null");

            var user = _genericRepository.GetFirstOrDefault<User>(x => x.EmailAddress == email);

            if (user == null)
                throw new Exception("User not found");

            return user;

        }

        public Role GetRoleById(int roleId)
        {
            return _genericRepository.GetById<Role>(roleId);
        }

        public User GetExistingUser(string emailAddress, string username)
        {
            if (string.IsNullOrEmpty(emailAddress) && string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Email address and username cannot both be null or empty");
            }

            var user = _genericRepository.GetFirstOrDefault<User>(x =>
                x.EmailAddress == emailAddress || x.UserName == username);

            return user;
        }

        public Role GetRoleByName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Role name cannot be null or empty");
            }

            var role = _genericRepository.GetFirstOrDefault<Role>(x => x.Name == roleName);

            return role;
        }

        public void InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            _genericRepository.Insert(user);
        }
    }
}
