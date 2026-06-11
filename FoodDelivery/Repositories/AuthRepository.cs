using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AuthRepository> _logger;

        public AuthRepository(
            ApplicationDbContext context,
            ILogger<AuthRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task RegisterAsync(User user)
        {
            try
            {
                _logger.LogInformation(
                    "Registering user {Email}",
                    user.Email);

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while registering user");

                throw;
            }
        }

        public async Task<User?> LoginAsync(LoginDTO dto)
        {
            try
            {
                _logger.LogInformation(
                    "Login attempt for {Email}",
                    dto.Email);

                return await _context.Users
                    .FirstOrDefaultAsync(
                        u => u.Email == dto.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while logging in");

                throw;
            }
        }

        public async Task<bool> EmailExistsAsync(
            string email)
        {
            try
            {
                return await _context.Users
                    .AnyAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while checking email");

                throw;
            }
        }
    }
}