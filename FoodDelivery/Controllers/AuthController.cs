using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.DTOs;

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
			_context.Users.Remove(users);
			_context.SaveChanges();
			return Ok("user deleted");
        }
    }
}
