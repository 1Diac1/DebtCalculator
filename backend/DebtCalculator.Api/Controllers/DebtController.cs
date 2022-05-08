using System.Security.Claims;
using DebtCalculator.BLL.Services;
using DebtCalculator.Api.Requests;
using DebtCalculator.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DebtCalculator.Api.Contracts.V1;
using DebtCalculator.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace DebtCalculator.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DebtController : ControllerBase
    {
        private readonly IDebtService _debtService;
        private readonly IDebtRepository _debtRepository;

        public DebtController(
            IDebtService debtService, 
            IDebtRepository debtRepository)
        {
            _debtService = debtService;
            _debtRepository = debtRepository;
        }

        [HttpGet(ApiRoutes.Debt.GetAllFromUser)]
        public async Task<IActionResult> GetAllAsync()
        {
            var userName = User.FindFirstValue("userName");

            if (userName is null)
                return new BadRequestObjectResult("User not found.");

            var debts = await _debtRepository.GetAllFromUserName(userName);

            return Ok(debts);
        }

        [HttpPost(ApiRoutes.Debt.Add)]
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
