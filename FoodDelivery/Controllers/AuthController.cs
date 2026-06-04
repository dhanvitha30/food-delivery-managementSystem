using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.DTOs;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodDelivery.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
    public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public AuthController(ApplicationDbContext context)
		{
			_context = context;
		}

        [HttpPost("register")]
		public IActionResult Register(RegisterDto dto)
		{
			var user = new User
			{
				Name = dto.Name,
				Email = dto.Email,
				Password = dto.Password,
				Role = dto.Role,
			};
			_context.Users.Add(user);
			_context.SaveChanges();
			return Ok(new { message = "User registered successfully" });
		}
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _context.Users
                .FirstOrDefault(u =>
                    u.Email == dto.Email &&
                    u.Password == dto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("ThisIsMySuperSecretJwtKey123456789")
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

            var jwtToken = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return Ok(new
            {
                token = jwtToken,
                message = "Login Successful"
            });
        }
    }
}
