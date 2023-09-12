using System.Text;
using Core.Entities.Auth;
using Application.DTOs.User;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using Konscious.Security.Cryptography;

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
                string hash = CreateHash(userDTO.Password);
                User user = new(userDTO.Username, userDTO.Email, hash);

                _unit.UserRepository.Add(user);
                await _unit.Commit();

                return "Usuário registrado com sucesso!";
            }
            catch
            { throw; }
        }

        private string CreateHash(string password)
        {
            using var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            byte[] hashBytes = hasher.GetBytes(32);
            string teste = Convert.ToBase64String(hashBytes);

            return teste;
        }
    }
}