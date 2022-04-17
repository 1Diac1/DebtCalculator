using Microsoft.EntityFrameworkCore;
using DebtCalculator.Core.Models;
using System.Threading.Tasks;
using System;

namespace DebtCalculator.DAL.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // comment
            if (!await context.Debts.AnyAsync())
            {
                await context.AddRangeAsync(
                    new Debt
                    {
                        Name = "Задолженность 1",
                        Description = "Какое-то дополнение",
                        Amount = 12000,
                        Created = DateTime.Now.ToString("G"),
                        UserId = 1,
                        CreditorId = 2
                    }, new Debt
                    {
                        Name = "Задолженность 2",
                        Description = "Какое-то дополнение 2",
                        Amount = 123123123,
                        Created = DateTime.Now.ToString("G"),
                        UserId = 1,
                        CreditorId = 2
                    },
                    new Debt
                    {
                        Name = "Задолженность 3",
                        Description = "Какое-то дополнение 3",
                        Amount = 123123123,
                        Created = DateTime.Now.ToString("G"),
                        UserId = 1,
                        CreditorId = 2
                    });
            }

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
