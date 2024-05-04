using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Infrastructure.Implementations.GenericRepo;
using Infrastructure.Implementations.Services;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependency
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("Infrastructure")));

            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddScoped<IDbInitilizer, DbInitilizer>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IHomeServices, HomeServices>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
