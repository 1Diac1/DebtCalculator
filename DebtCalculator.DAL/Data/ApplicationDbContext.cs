using Microsoft.EntityFrameworkCore;
using DebtCalculator.Core.Models;

namespace DebtCalculator.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Debt> Debts { get; set; }
        public DbSet<User> Users { get; set; }

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
