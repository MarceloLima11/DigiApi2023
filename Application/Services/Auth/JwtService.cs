using System.Text;
using System.Security.Claims;
using Application.Interfaces;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Services.Auth
{
    public class JwtService : IJwtService
    {
        private readonly string _secretKey;
        private const string _alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public JwtService(IServiceProvider serviceProvider)
        {
            _secretKey = GenereateSecret();
        }

        public string GenerateToken(Guid id)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateEmailConfirmationToken(int length) // change nome, Generate alphanumeric token?
        {
            var random = new Random();
            var token = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(_alphaNumeric.Length);
                token.Append(_alphaNumeric[index]);
            }

            return token.ToString();
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
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            string secretKey = BitConverter.ToString(randomBytes).Replace("-", "").ToLower();

            return secretKey;
        }
    }
}