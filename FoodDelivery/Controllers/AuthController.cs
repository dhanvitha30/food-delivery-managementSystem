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
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
		[HttpPut("{id}")]
		public IActionResult UpdateUser(int id,	RegisterDto dto)
		{
			var user = _context.Users.Find(id);
			if (user == null)
				return NotFound();
			user.Name = dto.Name;
			user.Email = dto.Email;
			user.Password = dto.Password;
			user.Role = dto.Role;
			_context.SaveChanges();
			return Ok("user updated");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteUser(int id)
		{
			var user = _context.Users.Find(id);
			if (user == null)
				return NotFound();
			_context.Users.Remove(user);
			_context.SaveChanges();
			return Ok("user deleted");
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
			[HttpGet("users")]
			public IActionResult GetAllUsers()
            {
                var users = _context.Users.ToList();
                return Ok(users);
            }
			[HttpGet("users/{id}")]
			public IActionResult GetUserById(int id)

            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound("user not found");
                }
                return Ok(user);
            }
			[HttpDelete("users/{id}")]
			public IActionResult DeleteUserById(int id)

            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound("user not found");
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok("user deleted Successfully");
            }
        }
}
