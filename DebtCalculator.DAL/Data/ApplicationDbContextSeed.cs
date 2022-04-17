using System.Threading.Tasks;
using DebtCalculator.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtCalculator.DAL.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                await context.AddRangeAsync
                (
                    new User
                    {
                        FirstName = "Nikita",
                        LastName = "Nikitov",
                        Age = 15
                    }, 
                    new User
                    {
                        FirstName = "Ruslan",
                        LastName = "Ruslanov",
                        Age = 16
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
