using System.Text.RegularExpressions;
using Core.Validations;

namespace Core.Entities.Auth
{
    public class User
    {
        public User(string username, string email, string passwordHash)
        { ValidateUser(username, email, passwordHash); }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        private void ValidateUser(string username, string email, string passwordHash)
        {
            DomainException.When(username.Length < 3, "Nome de usuário inválido. Minímo de 3 caracteres.");

            DomainException.When(username.Length > 15, "Nome de usuário inválido. Máximo de 15 caracteres.");

            DomainException.When(!ValidateEmail(email), "Email inválido.");

            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public void ValidatePassword(string password)
        {
            DomainException.When(password.Length < 8, "Senha inválida. Tamnho menor que o mínimo permitido.");

            DomainException.When(password.Length > 20, "Senha inválida. Tamanho maior que o permitido.");

            bool senhaValida = !Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*[0-9]).+$");
            DomainException.When(senhaValida, "Formato de senha inválido.");
        }
    }
}