using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using DebtCalculator.Core.Models;
using DebtCalculator.Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DebtCalculator.BLL.Services.Implementation
{
    public class JwtService : IJwtService
    {
        private readonly AuthOptions _authOptions;

        public JwtService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }

        public async Task<string> GetTokenAsync(User user)
        {
            var identity = await Task.Factory.StartNew(() => GetIdentity(user));
            
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                notBefore: DateTime.Now,
                claims: identity.Claims,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(_authOptions.Lifetime)),
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", user.UserName),
                new Claim("firstName",  user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("role", "User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                "username", "role");

            return claimsIdentity;
        }
    }
}