using Utilities.Helpers;
using Core.Entities.Auth;
using Application.DTOs.User;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;

namespace Application.Services.Auth
{
    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unit;

        public RegisterService(IUnitOfWork unit)
        { _unit = unit; }

        public async Task<string> Register(UserRegistrationDTO userDTO)
        {
            try
            {
                await AlreadyExist(userDTO.Username, userDTO.Email);

                byte[] salt = SecurityUtility.GenerateSalt();
                string hash = SecurityUtility.CreateHash(userDTO.Password, salt);
                User user = new(userDTO.Username, userDTO.Email, hash);

                _unit.UserRepository.Add(user);
                await _unit.Commit();

                return "Usuário registrado com sucesso!";
            }
            catch
            { throw; }
        }

        public async Task AlreadyExist(string username, string email)
        {
            bool usernameVerify = await _unit.UserRepository.UserVerify(x => x.Username == username);
            bool emailVerify = await _unit.UserRepository.UserVerify(x => x.Email == email);

            if (usernameVerify) throw new Exception("Username já existe.");
            if (emailVerify) throw new Exception("Email já cadastrado.");
        }
    }
}