using System.Text;
using Utilities.Helpers;
using Core.Entities.Auth;
using Application.DTOs.User;
using System.Security.Claims;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly IServiceProvider _serviceProvider;

        public AuthService(IServiceProvider serviceProvider)
        {
            _secretKey = GenereateSecret();
            _serviceProvider = serviceProvider;
        }

        public async Task<string> GenerateToken(UserDTO userDTO)
        {
            using var scope = _serviceProvider.CreateScope();
            var unit = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            User user = await unit.UserRepository.GetUser(userDTO.Username);


            if (user == null)
                throw new UnauthorizedAccessException("Usuário não cadastrado.");
            else
            {
                string[] saltedHash = user.PasswordHash.Split(':');
                if (!SecurityUtility.VerifyPassword(userDTO.Password, saltedHash[0], saltedHash[1]))
                    throw new UnauthorizedAccessException("Senha inválida.");
            }

            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            { return false; }
        }

        private string GenereateSecret()
        {
            byte[] randomBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            string secretKey = BitConverter.ToString(randomBytes).Replace("-", "").ToLower();

            return secretKey;
        }
    }
}