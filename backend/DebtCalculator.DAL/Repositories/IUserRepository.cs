using System.Collections.Generic;
using DebtCalculator.Core.Models;
using System.Threading.Tasks;

namespace DebtCalculator.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task UpdateAsync(User user);
        Task AddAsync(User user);
        Task DeleteAsync(int id);
    }
}
