using FoodDelivery.DTOs;

namespace FoodDelivery.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);

        Task<string?> LoginAsync(LoginDTO dto);
    }
}