using Application.DTOs.Account;
using Application.DTOs.User;
using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Entities.Constants;
using Entities.Models;
using Entities.Utility;

namespace Infrastructure.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository _genericRepository;

        public AdminService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<UserDetailDto> GetAllUsers()
        {
            var users = _genericRepository.Get<User>().Select(u => new UserDetailDto
            {
                Id = u.Id,
                RoleId = u.RoleId,
                EmailAddress = u.EmailAddress,
                ImageURL = u.ImageURL ?? "",
                Username = u.UserName,
                Name = u.FullName,
                RoleName = _genericRepository.GetById<Role>(u.RoleId).Name
            }).ToList();

            return users;
        }

        public bool RegisterAdmin(RegisterDto register)
        { 
            var existingUser = _genericRepository.Get<User>().FirstOrDefault(u => u.EmailAddress == register.EmailAddress);

            if (existingUser == null)
            {
                var role = _genericRepository.Get<Role>().FirstOrDefault(r => r.Name == "Admin");

                var appUser = new User
                {
                    FullName = register.FullName,
                    EmailAddress = register.EmailAddress,
                    RoleId = role!.Id,
                    Password = Password.HashSecret(Constants.Passwords.AdminPassword),
                    UserName = register.Username,
                    MobileNo = register.MobileNumber,
                    ImageURL = register.ImageURL
                };

                _genericRepository.Insert(appUser);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
