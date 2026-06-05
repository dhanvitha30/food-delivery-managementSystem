using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User? GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}