using DebtCalculator.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using DebtCalculator.Core.Models;
using System.Collections.Generic;
using DebtCalculator.DAL.Data;
using System.Threading.Tasks;
using System;

namespace DebtCalculator.BLL.Services.Implementation
{
    public class DebtService : IDebtService
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public DebtService(
            IDebtRepository debtRepository, 
            IUserRepository userRepository, 
            ApplicationDbContext context)
        {
            _debtRepository = debtRepository;
            _userRepository = userRepository;
            _context = context;
        }

        public async Task RemovePartAsync(int debtId, decimal amount)
        {
            var debt = await _context.Debts.FirstOrDefaultAsync(d => d.Id == debtId);

            if (debt != null) debt.Amount -= amount;
            if (debt != null) debt.Modified = DateTime.Now.ToString("G");

            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(int userId, int creditorId, string name, string description, decimal amount)
        {
            var user = await _userRepository.GetAsync(userId);

            user.Debts.Add(new Debt
            {
                Name = name,
                Description = description,
                CreditorId = creditorId,
                UserId = userId,
                Amount = amount,
                Created = DateTime.Now.ToString("G")
            });

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAllAsync(int userId)
        {
            var user = await _userRepository.GetAsync(userId);
            var debts = await _debtRepository.GetAllFromUserIdAsync(user.Id);

            debts = new List<Debt>();
            user.Debts = new List<Debt>(); 

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Debt>> GetAllAsync()
        {
            var debts = await _debtRepository.GetAllAsync();

            return debts;
        }
    }
}
