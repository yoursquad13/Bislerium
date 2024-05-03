using Application.Interfaces.GenericRepo;
using Entities.Constants;
using Entities.Models;
using Entities.Utility;

namespace Infrastructure.Persistence.Seed
{
    public class DbInitilizer(IGenericRepository genericRepository) : IDbInitilizer
    {
        public void Initialize()
        {
            try
            {
                if (!genericRepository.Get<Role>().Any())
                {
                    var admin = new Role()
                    {
                        Name = Constants.Roles.Admin
                    };
                    var blogger = new Role()
                    {
                        Name = Constants.Roles.Blogger
                    };

                    genericRepository.Insert(admin);
                    genericRepository.Insert(blogger);
                }
                if (genericRepository.Get<User>().Any()) return;

                var adminRole = genericRepository.GetFirstOrDefault<Role>(x => x.Name == Constants.Roles.Admin);

                var superAdminUser = new User
                {
                    FullName = "Admin",
                    EmailAddress = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    Password = Password.HashSecret(Constants.Passwords.AdminPassword),
                    RoleId = adminRole.Id,
                    MobileNo = "+977 9841234567",
                    ImageURL = null
                };

                genericRepository.Insert(superAdminUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
