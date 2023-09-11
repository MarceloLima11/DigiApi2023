using Core.Validations;

namespace Core.Entities.Auth
{
    public class User
    {
        public User(Guid id, string username, string email, string passwordHash)
        {
            DomainException.When(id is null, "Id de usúario inválido.");

            Id = id;
            ValidateUser(username, email, passwordHash);
        }

        public User(string username, string email, string passwordHash)
        { ValidateUser(username, email, passwordHash); }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        private void ValidateUser(string username, string email, string passwordHash)
        {
            DomainException.When(username < 3, "Nome de usuário inválido. Minímo de 3 caracteres.")

            DomainException.When(username > 15, "Nome de usuário inválido. Máximo de 15 caracteres.");

            DomainException.When(ValidateEmail(email), "Email inválido.");

            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        private void bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}