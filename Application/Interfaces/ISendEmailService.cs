namespace Application.Interfaces
{
    public interface ISendEmailService
    {
        Task Confirmation(string email, string subject, string message);
        Task<bool> ResetPassword();
    }
}