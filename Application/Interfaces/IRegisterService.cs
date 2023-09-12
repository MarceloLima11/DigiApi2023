using Application.DTOs.User;

namespace Application.Interfaces
{
    public interface IRegisterService
    {
        Task<string> Register(UserRegistrationDTO user);
    }
}