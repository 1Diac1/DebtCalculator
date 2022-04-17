using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DebtCalculator.Core.Models;
using DebtCalculator.DAL.Data;
using System.Threading.Tasks;

namespace DebtCalculator.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            var entity = await this.GetAsync(user.Id);

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await this.GetAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
