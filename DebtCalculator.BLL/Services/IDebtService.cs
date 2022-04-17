using DebtCalculator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtCalculator.BLL.Services
{
    public interface IDebtService
    {
        Task AddAsync(int userId, int creditorId, string name, string description, decimal amount);
        Task RemovePartAsync(int debtId, decimal amount);
        Task<IEnumerable<Debt>> GetAllAsync();
        Task RemoveAllAsync(int userId);
    }
}
