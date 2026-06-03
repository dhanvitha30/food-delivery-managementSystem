using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.DTOs;
using System.Security.Cryptography.X509Certificates;

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
			var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);
			if (user == null)
			{
				return Unauthorized("Invalid email or password");
			}
			return Ok(new
			{
				message = "Login Successful",
				user.Name,
				user.Email,
				user.Role

			});
		}
        }
}
