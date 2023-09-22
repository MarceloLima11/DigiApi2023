using Utilities.Helpers;
using Core.Entities.Auth;
using Application.DTOs.User;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;

namespace Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;
        private readonly IJwtService _jwtService;
        public UserService(IUnitOfWork unit,
        IJwtService jwtService)
        {
            _unit = unit;
            _jwtService = jwtService;
        }

        public async Task<string> Login(UserDTO userDTO)
        {
            User user = await _unit.UserRepository.GetUser(userDTO.Username);

            if (user == null)
                throw new UnauthorizedAccessException("Usuário não cadastrado.");
            else
            {
                string[] saltedHash = user.PasswordHash.Split(':');
                if (!SecurityUtility.VerifyPassword(userDTO.Password, saltedHash[0], saltedHash[1]))
                    throw new UnauthorizedAccessException("Senha inválida.");
            }

            return _jwtService.GenerateToken(user.Id);
        }

        public async Task<string> Register(UserRegistrationDTO userDTO)
        {
            try
            {
                await AlreadyExist(userDTO.Username, userDTO.Email);

                User user = new(userDTO.Username, userDTO.Email, userDTO.Password);
                user.ValidatePassword(userDTO.Password);

                byte[] salt = SecurityUtility.GenerateSalt();
                string hash = SecurityUtility.CreateHash(userDTO.Password, salt);
                user.PasswordHash = hash;

                _unit.UserRepository.Add(user);
                await _unit.Commit();

                string confirmEmailToken = _jwtService.GenerateEmailConfirmationToken(
                    user.Username, user.Email);
                var emailConfirmationData = new EmailConfirmation(confirmEmailToken, user.Id);
                _unit.EmailConfirmationRepository.Add(emailConfirmationData);
                await _unit.Commit();

                return "Usuário registrado com sucesso!";
            }
            catch
            { throw; }
        }

        private async Task AlreadyExist(string username, string email)
        {
            bool usernameVerify = await _unit.UserRepository.UserVerify(x => x.Username == username);
            bool emailVerify = await _unit.UserRepository.UserVerify(x => x.Email == email);

            if (usernameVerify) throw new Exception("Username já existe.");
            if (emailVerify) throw new Exception("Email já cadastrado.");
        }
    }
}