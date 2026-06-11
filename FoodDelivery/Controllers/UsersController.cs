using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IUserService userService,
            ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(
                    await _userService.GetUsersAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error fetching users");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user =
                    await _userService.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound("User not found");

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error fetching user");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(
            int id,
            RegisterDto dto)
        {
            try
            {
                return Ok(
                    await _userService
                        .UpdateUserAsync(id, dto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error updating user");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                return Ok(
                    await _userService
                        .DeleteUserAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error deleting user");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }
    }
}