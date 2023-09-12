using System.Text;
using Core.Entities.Auth;
using Application.DTOs.User;
using System.Security.Claims;
using Application.Interfaces;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Konscious.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces.UnitOfWork;

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

            if (user == null || !VerifyPassword(userDTO.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Usuário não autorizado.");

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
            {
                return false;
            }
        }

        public bool VerifyPassword(string password, string hash)
        {
            byte[] hashBytes = Convert.FromBase64String(hash);
            using var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            byte[] computedHashBytes = hasher.GetBytes(hashBytes.Length);

            return hashBytes.SequenceEqual(computedHashBytes);
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