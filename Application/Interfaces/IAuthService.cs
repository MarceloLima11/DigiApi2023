namespace Application.Interfaces
{
    public interface IAuthService
    {
        bool ValidateToken(string token);
        string GenerateToken(string developerId);
    }
}