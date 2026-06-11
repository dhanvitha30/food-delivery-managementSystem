using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;
using FoodDelivery.Models;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository repository,
            ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _repository.GetUsersAsync();
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
                return await _repository.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error fetching user");

                throw;
            }
        }

        public async Task<string> UpdateUserAsync(
            int id,
            RegisterDto dto)
        {
            try
            {
                var user =
                    await _repository.GetUserByIdAsync(id);

                if (user == null)
                    return "User not found";

                user.Name = dto.Name;
                user.Email = dto.Email;
                user.Password = dto.Password;
                user.Role = dto.Role;

                await _repository.UpdateUserAsync(user);

                return "User updated successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error updating user");

                throw;
            }
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            try
            {
                var user =
                    await _repository.GetUserByIdAsync(id);

                if (user == null)
                    return "User not found";

                await _repository.DeleteUserAsync(user);

                return "User deleted successfully";
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