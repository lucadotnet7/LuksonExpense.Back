using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using LuksonExpense.Domain.Models;
using LuksonExpense.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace LuksonExpense.Application.Abstractions.Authentication
{
    public sealed class AuthProvider(
        IConfiguration configuration, 
        IHttpContextAccessor contextAccessor,
        IUserRepository userRepository)
    {
        public string CreateToken(User user)
        {
            string secretKey = configuration["Jwt:SecretKey"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                ]),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["Jwt:ExpiresInMinutes"])),
                SigningCredentials = credentials,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }

        public async Task<User> GetCurrentUser()
        {
            string? email = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
                throw new SecurityTokenValidationException("Error obteniendo datos del token de seguridad.");

            User? user = await userRepository.GetUserByEmail(email);

            if (user is null)
                throw new ValidationException("Error de validación de usuario.");

            return user;
        }
    }
}
