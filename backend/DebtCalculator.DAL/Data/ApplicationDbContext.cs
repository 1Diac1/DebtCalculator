using Microsoft.EntityFrameworkCore;
using DebtCalculator.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DebtCalculator.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Debt> Debts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(new User 
                    { 
                        Id = 2,
                        FirstName = "Ruslan",
                        LastName = "Ruslanov",
                        Age = 16
                    });
            
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Nikita",
                    LastName = "Nikitov",
                    Age = 16
                });
        }
    }
}
