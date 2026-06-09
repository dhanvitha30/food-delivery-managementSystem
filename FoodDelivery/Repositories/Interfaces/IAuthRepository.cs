using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        void Register(User user);
        User? Login(LoginDTO dto);
        bool EmailExists(string email);
    }
}