namespace Application.Interfaces
{
    public interface IJwtService
    {
        bool ValidateToken(string token);
        string GenerateToken(Guid id);
        string GenerateEmailConfirmationToken(int length = 6);
    }
}