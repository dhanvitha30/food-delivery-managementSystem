using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodDelivery.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(
        IAuthRepository repository,
        IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public string Register(RegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return "Name is required";

            if (string.IsNullOrWhiteSpace(dto.Email))
                return "Email is required";

            if (string.IsNullOrWhiteSpace(dto.Password))
                return "Password is required";

            if (_repository.EmailExists(dto.Email))
                return "Email already exists";

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };
            Console.WriteLine($"Name: {dto.Name}");
            Console.WriteLine($"Email: {dto.Email}");
            Console.WriteLine($"Password: {dto.Password}");
            Console.WriteLine($"Role: {dto.Role}");

            _repository.Register(user);
            Console.WriteLine(user.Password);
            Console.WriteLine(user.Role);

            return "User registered successfully";
        }

        public string Login(LoginDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                return null;

            if (string.IsNullOrWhiteSpace(dto.Password))
                return null;

            var user = _repository.Login(dto);

            Console.WriteLine($"Email: {dto.Email}");
             Console.WriteLine($"Password: {dto.Password}");
             Console.WriteLine(user == null ? "User Not Found" : "User Found"); 

            if (user == null)
                return null;

            var claims = new[]
                {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}