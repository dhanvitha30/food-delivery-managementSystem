using Microsoft.AspNetCore.Mvc;
using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IAuthService authService,
            ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var result =
                    await _authService.RegisterAsync(dto);

                return Ok(new
                {
                    message = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while registering user");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var token =
                    await _authService.LoginAsync(dto);

                if (token == null)
                {
                    return Unauthorized(
                        "Invalid email or password");
                }

                return Ok(new
                {
                    token,
                    message = "Login Successful"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while logging in");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }
    }
}