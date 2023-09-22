using Application.DTOs.User;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(UserRegistrationDTO userDTO);
        Task<string> Login(UserDTO userDTO);
    }
}