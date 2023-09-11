using Application.DTOs.User;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        bool ValidateToken(string token);
        string GenerateToken(string developerId);
        Task<string> Register(UserRegistrationDTO user);
    }
}