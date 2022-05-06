using DebtCalculator.DAL.Repositories.Implementation;
using DebtCalculator.BLL.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DebtCalculator.DAL.Repositories;
using DebtCalculator.Root.Installers;
using Microsoft.EntityFrameworkCore;
using DebtCalculator.BLL.Services;
using DebtCalculator.Core.Models;
using DebtCalculator.DAL.Data;
using Microsoft.AspNetCore.Identity;

namespace DebtCalculator.Root
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Filename=Debt.db"));

            services.AddJwtInstaller(configuration);

            services.AddIdentity<User, IdentityRole<int>>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 2;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDebtRepository, DebtRepository>();

            return services;
        }

        public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDebtService, DebtService>();

            return services;
        }
    }
}
