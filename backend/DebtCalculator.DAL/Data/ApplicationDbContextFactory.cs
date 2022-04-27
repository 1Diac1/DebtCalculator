using Microsoft.EntityFrameworkCore;

namespace DebtCalculator.DAL.Data
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("Filename=Debts.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
