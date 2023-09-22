using Core.Validations;

namespace Core.Entities.Auth
{
    public class EmailConfirmation
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool Confirmed { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public EmailConfirmation(string token, Guid userId)
        {
            DomainException.When(userId == null, "Id do usuário nulo.");
            DomainException.When(String.IsNullOrEmpty(token), "Id do usuário nulo.");

            Token = token;
            UserId = userId;
        }
    }
}