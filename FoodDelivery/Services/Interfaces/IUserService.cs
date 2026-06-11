using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task<string> UpdateUserAsync(int id, RegisterDto dto);

        Task<string> DeleteUserAsync(int id);
    }
}