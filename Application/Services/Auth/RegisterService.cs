using System.Text;
using Core.Entities.Auth;
using Application.DTOs.User;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using System.Security.Cryptography;
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
                byte[] salt = GenerateSalt(16);
                string hash = CreateHash(userDTO.Password, salt);
                User user = new(userDTO.Username, userDTO.Email, hash);

                _unit.UserRepository.Add(user);
                await _unit.Commit();

                return "Usuário registrado com sucesso!";
            }
            catch
            { throw; }
        }

        private string CreateHash(string password, byte[] salt)
        {
            using var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            hasher.Salt = salt;
            hasher.MemorySize = 65536;
            hasher.DegreeOfParallelism = 4;
            hasher.Iterations = 4;

            byte[] hashBytes = hasher.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }

        public byte[] GenerateSalt(int size)
        {
            using var rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[size];
            rng.GetBytes(salt);
            return salt;
        }
    }
}