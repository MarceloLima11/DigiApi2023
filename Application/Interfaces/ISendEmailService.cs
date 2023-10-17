namespace Application.Interfaces
{
    public interface ISendEmailService
    {
        Task<string> SendConfirmationEmail(string email);
        Task<string> SendPasswordResetEmail(string username);
    }
}