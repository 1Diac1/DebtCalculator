using DebtCalculator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtCalculator.DAL.Repositories
{
    public interface IDebtRepository
    {
        Task<IEnumerable<Debt>> GetAllFromUserIdAsync(int userId);
        Task<IEnumerable<Debt>> GetAllFromUserName(string username);
        Task<IEnumerable<Debt>> GetAllAsync();
        Task<Debt> GetAsync(int id);
        Task UpdateAsync(Debt debt);
        Task AddAsync(Debt debt);
        Task DeleteAsync(int id);
    }
}
