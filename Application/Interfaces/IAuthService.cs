using Application.DTOs.User;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        bool ValidateToken(string token);
        Task<string> GenerateToken(UserDTO userDTO);
    }
}