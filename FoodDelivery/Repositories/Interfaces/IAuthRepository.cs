using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task RegisterAsync(User user);

        Task<User?> LoginAsync(LoginDTO dto);

        Task<bool> EmailExistsAsync(string email);
    }
}