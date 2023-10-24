using Utilities.Helpers;
using Core.Entities.Auth;
using Application.DTOs.User;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using SendGrid.Helpers.Errors.Model;
using Microsoft.IdentityModel.Tokens;
using Application.Common.Exceptions;
using Application.DTOs.User.Request;

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

                string confirmEmailToken = _jwtService.GenerateEmailConfirmationToken();
                var emailConfirmationData = new EmailConfirmation(confirmEmailToken, user.Id);
                _unit.EmailConfirmationRepository.Add(emailConfirmationData);
                await _unit.Commit();

                return "Usuário registrado com sucesso!";
            }
            catch
            { throw; }
        }

        public async Task<string> ConfirmEmail(string email, string token)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new BadRequestException("Email inválido.");
                if (token.Length != 6) throw new InvalidTokenException();

                User user = await _unit.UserRepository.GetUserByEmail(email)
                    ?? throw new NotFoundException("Usuário não cadastrado!");

                var emailConfirmation = await _unit.EmailConfirmationRepository.GetEmailConfirmationByUser(user.Id);
                if (emailConfirmation.Confirmed) return "Usuário já verificado.";

                if (emailConfirmation.Expiration < DateTime.UtcNow)
                    throw new TokenExpiredException(emailConfirmation.Expiration.ToLocalTime());

                if (!emailConfirmation.Token.Equals(token))
                    throw new SecurityTokenValidationException("Código inválido");


                emailConfirmation.Confirmed = true;
                _unit.EmailConfirmationRepository.Update(emailConfirmation);
                await _unit.Commit();

                return "Email confirmado com sucesso!";
            }
            catch
            { throw; }
        }

        public async Task<string> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                User user = await _unit.UserRepository.GetUserByEmail(resetPasswordDTO.Email)
                    ?? throw new UnauthorizedAccessException("Usuário não encontrado");

                var passwordResetData = await _unit.PasswordResetRepository.GetByUserId(user.Id)
                    ?? throw new InvalidTokenException();

                if (!passwordResetData.Token.Equals(resetPasswordDTO.Token))
                    throw new InvalidTokenException();

                if (passwordResetData.Expiration < DateTime.UtcNow) // mover essa validação para utils
                    throw new TokenExpiredException(passwordResetData.Expiration);

                user.ValidatePassword(resetPasswordDTO.Password);

                byte[] salt = SecurityUtility.GenerateSalt();
                string hash = SecurityUtility.CreateHash(resetPasswordDTO.Password, salt);
                user.PasswordHash = hash;
                _unit.UserRepository.Update(user);
                await _unit.Commit();

                return "Senha atualizada com sucesso!";
            }
            catch
            { throw; }
        }

        private async Task AlreadyExist(string username, string email)
        {
            bool usernameVerify = await _unit.UserRepository.UserVerify(x => x.Username == username);
            bool emailVerify = await _unit.UserRepository.UserVerify(x => x.Email == email);

            if (usernameVerify) throw new NotFoundException("Username já existe.");
            if (emailVerify) throw new NotFoundException("Email já cadastrado.");
        }
    }
}