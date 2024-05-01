using Application.Interfaces.GenericRepo;
using Infrastructure.Implementations.GenericRepo;
using Infrastructure.Persistence;
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

            //services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddTransient<IGenericRepository, GenericRepository>();
            //services.AddTransient<IFileUploadService, FileUploadService>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
