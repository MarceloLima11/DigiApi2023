namespace Application.Interfaces
{
    public interface IJwtService
    {
        bool ValidateToken(string token);
        string GenerateToken(Guid id);
        string GenerateEmailConfirmationToken(string username, string email);
    }
}