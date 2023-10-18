namespace Core.Entities.Auth
{
    public class PasswordReset
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public Guid UserId { get; set; }

        public PasswordReset(string token, Guid userId)
        {
            Token = token;
            UserId = userId;
            Expiration = DateTime.UtcNow.AddHours(2);
        }
    }
}