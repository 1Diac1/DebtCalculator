using System.Threading.Tasks;
using DebtCalculator.Api.Contracts.V1;
using DebtCalculator.Api.Requests;
using DebtCalculator.BLL.Services;
using DebtCalculator.Core.Models;
using DebtCalculator.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DebtCalculator.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthController(
            ApplicationDbContext context, 
            IJwtService jwtService, 
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return new BadRequestObjectResult("Login or password invalid.");

            var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (checkPassword is false)
                return new BadRequestObjectResult("Login or password invalid.");

            var response = await _jwtService.GetTokenAsync(user.UserName, user.Role);

            return Ok(new { Token = response });
        }

        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var userEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userEmail is not null)
                return new BadRequestObjectResult("User with this email already exists.");

            var userUserName = await _userManager.FindByNameAsync(request.UserName);

            if (userUserName is not null)
                return new BadRequestObjectResult("User with this user name already exists.");

            var response = await _jwtService.GetTokenAsync(request.UserName, request.Role);

            return Ok(new { Token = response });
        }
    }
}