using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetUserById(int id);
        string UpdateUser(int id, RegisterDto dto);
        string DeleteUser(int id);
    }
}