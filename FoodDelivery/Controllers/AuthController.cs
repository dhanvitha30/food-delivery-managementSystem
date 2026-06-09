using Microsoft.AspNetCore.Mvc;
using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;
using Npgsql;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var result = _authService.Register(dto);

            return Ok(new
            {
                message = result
            });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var token = _authService.Login(dto);

            if (token == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new
            {
                token,
                message = "Login Successful"
            });
        }
    }
}