using System.Linq;
using System.Threading.Tasks;
using DebtCalculator.Api.Contracts.V1;
using DebtCalculator.Api.Requests;
using DebtCalculator.BLL.Services;
using DebtCalculator.Core.Models;
using DebtCalculator.DAL.Data;
using DebtCalculator.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DebtCalculator.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthController(
            ApplicationDbContext context, 
            IJwtService jwtService, 
            UserManager<User> userManager,
            SignInManager<User> signInManager, 
            IUserRepository userRepository)
        {
            _context = context;
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
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

            var userUserName =await _userManager.FindByNameAsync(request.UserName);

            if (userUserName is not null)
                return new BadRequestObjectResult("User with this user name already exists.");

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Role = request.Role,
                Age = request.Age
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded is false)
                return new BadRequestObjectResult(result.Errors.Select(e => e.Description));
            
            var response = await _jwtService.GetTokenAsync(newUser.UserName, newUser.Role);

            return Ok(new { Token = response });
        }
    }
}