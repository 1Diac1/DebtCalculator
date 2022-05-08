using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DebtCalculator.Core.Models;
using DebtCalculator.DAL.Data;
using System.Threading.Tasks;
using System.Linq;

namespace DebtCalculator.DAL.Repositories.Implementation
{
    public class DebtRepository : IDebtRepository
    {
        private readonly ApplicationDbContext _context;

        public DebtRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Debt>> GetAllFromUserIdAsync(int userId)
        {
            var debts = await _context.Debts
                .Where(d => d.UserId == userId)
                .ToListAsync();

            return debts;
        }

        public async Task<IEnumerable<Debt>> GetAllFromUserName(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            
            var debts = await _context.Debts
                .Where(d => d.UserId == user.Id)
                .ToListAsync();

            return debts;
        }

        public async Task<IEnumerable<Debt>> GetAllAsync()
        {
            var debts = await _context.Debts.ToListAsync();

            return debts;
        }

        public async Task<Debt> GetAsync(int id)
        {
            var debt = await _context.Debts.FirstOrDefaultAsync(d => d.Id == id);

            return debt;
        }

        public async Task AddAsync(Debt debt)
        {
            await _context.Debts.AddAsync(debt);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Debt debt)
        {
            var entity = await this.GetAsync(debt.Id);

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = this.GetAsync(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
