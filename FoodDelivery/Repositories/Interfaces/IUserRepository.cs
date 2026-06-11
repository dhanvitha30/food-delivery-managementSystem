using FoodDelivery.Models;

namespace FoodDelivery.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);
    }
}