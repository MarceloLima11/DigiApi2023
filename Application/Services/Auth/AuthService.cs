using System.Text;
using System.Security.Claims;
using Application.Interfaces;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Core.Interfaces.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IAuthenticateUser _authUser;

        public AuthService(IServiceProvider serviceProvider)
        {
            //_authUser = authUser;
            _serviceProvider = serviceProvider;
            _secretKey = GenereateSecret();
        }

        public string GenerateToken(string developerId)
        {
            if (!IsDeveloperAuthorized(developerId))
                throw new UnauthorizedAccessException("Usuário não autorizado.");

            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, developerId)
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

        public string GenereateSecret()
        {
            byte[] randomBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            string secretKey = BitConverter.ToString(randomBytes).Replace("-", "").ToLower();

            return secretKey;
        }

        private bool IsDeveloperAuthorized(string developerId)
        {
            using var scope = _serviceProvider.CreateScope();
            var authenticateService = scope.ServiceProvider.GetRequiredService<IAuthenticateUser>();
            return authenticateService.IsDeveloperAuthorized(developerId);
        }
    }
}