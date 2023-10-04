using Application.DTOs.User;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(UserDTO userDTO);
        Task<string> Register(UserRegistrationDTO userDTO);
        Task<string> ConfirmEmail(string email, string token);
        Task<string> ValidateToken(string email, string token);
        Task<string> ResetPassword(string email, string password);
    }
}