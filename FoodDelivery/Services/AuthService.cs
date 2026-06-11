using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Interfaces;
using FoodDelivery.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodDelivery.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IAuthRepository repository,
            IConfiguration configuration,
            ILogger<AuthService> logger)
        {
            _repository = repository;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return "Name is required";

                if (string.IsNullOrWhiteSpace(dto.Email))
                    return "Email is required";

                if (string.IsNullOrWhiteSpace(dto.Password))
                    return "Password is required";

                if (await _repository.EmailExistsAsync(dto.Email))
                    return "Email already exists";

                var user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = dto.Role
                };

                await _repository.RegisterAsync(user);

                _logger.LogInformation(
                    "User registered successfully {Email}",
                    dto.Email);

                return "User registered successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while registering user");

                throw;
            }
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Email))
                    return null;

                if (string.IsNullOrWhiteSpace(dto.Password))
                    return null;

                var user = await _repository.LoginAsync(dto);

                if (user == null)
                    return null;

                if (!BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.Password))
                    return null;

                var claims = new[]
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]!));

                var creds = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                _logger.LogInformation(
                    "User logged in successfully {Email}",
                    dto.Email);

                return new JwtSecurityTokenHandler()
                    .WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while logging in");

                throw;
            }
        }
    }
}