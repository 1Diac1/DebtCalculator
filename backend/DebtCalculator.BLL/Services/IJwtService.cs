using System.Threading.Tasks;
using DebtCalculator.Core.Models;

namespace DebtCalculator.BLL.Services
{
    public interface IJwtService
    {
        Task<string> GetTokenAsync(User user);
    }
}