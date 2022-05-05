using DebtCalculator.BLL.Services;
using DebtCalculator.Api.Requests;
using DebtCalculator.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DebtCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DebtController : ControllerBase
    {
        private readonly IDebtService _debtService;

        public DebtController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var debts = await _debtService.GetAllAsync();

            return Ok(debts);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] Debt debt)
        {
            await _debtService.AddAsync(debt.UserId, debt.CreditorId, debt.Name, debt.Description, debt.Amount);

            return Ok();
        }

        [HttpPost("remove-all")]
        public async Task<IActionResult> RemoveAllAsync([FromQuery] int userId)
        {
            await _debtService.RemoveAllAsync(userId);

            return Ok();
        }

        [HttpPost("remove-part")]
        public async Task<IActionResult> RemovePartAsync([FromBody] DebtRemovePartRequest request)
        {
            await _debtService.RemovePartAsync(request.DebtId, request.Amount);

            return Ok();
        }
    }
}
