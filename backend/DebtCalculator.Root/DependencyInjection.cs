using DebtCalculator.DAL.Repositories.Implementation;
using DebtCalculator.BLL.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DebtCalculator.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using DebtCalculator.BLL.Services;
using DebtCalculator.DAL.Data;

namespace DebtCalculator.Root
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Memory"));

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
