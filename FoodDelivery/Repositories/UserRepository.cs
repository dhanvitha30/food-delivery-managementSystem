using FoodDelivery.Data;
using FoodDelivery.Interfaces;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            ApplicationDbContext context,
            ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                _logger.LogInformation(
                    "Fetching users");

                return await _context.Users
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error fetching users");

                throw;
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Fetching user {Id}",
                    id);

                return await _context.Users
                    .FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error fetching user");

                throw;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                _logger.LogInformation(
                    "Updating user {Id}",
                    user.Id);

                _context.Users.Update(user);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error updating user");

                throw;
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            try
            {
                _logger.LogInformation(
                    "Deleting user {Id}",
                    user.Id);

                _context.Users.Remove(user);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error deleting user");

                throw;
            }
        }
    }
}