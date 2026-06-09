using FoodDelivery.DTOs;

namespace FoodDelivery.Interfaces
{
    public interface IAuthService
    {
        string Register(RegisterDto dto);
        string Login(LoginDTO dto);
    }
}