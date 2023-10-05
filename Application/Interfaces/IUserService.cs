using Application.DTOs.User;
using Application.DTOs.User.Request;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(UserDTO userDTO);
        Task<string> Register(UserRegistrationDTO userDTO);
        Task<string> ConfirmEmail(string email, string token);
        Task<string> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}