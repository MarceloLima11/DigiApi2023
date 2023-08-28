namespace Core.Interfaces.Auth
{
    public interface IAuthenticateUser
    {
        bool IsDeveloperAuthorized(string developerId);
    }
}