namespace Application.Interfaces
{
    public interface ISendEmailService
    {
        Task Confirmation(string email);
        Task<bool> ResetPassword();
    }
}