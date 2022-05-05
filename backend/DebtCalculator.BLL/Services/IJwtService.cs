using System.Threading.Tasks;

namespace DebtCalculator.BLL.Services
{
    public interface IJwtService
    {
        Task<string> GetTokenAsync(string username, string password);
    }
}