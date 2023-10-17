using Core.Entities.Auth;
using Core.Interfaces.Base;

namespace Core.Interfaces.Auth
{
    public interface IEmailConfirmationRepository : IRepositoryBase<EmailConfirmation>
    {
        Task<EmailConfirmation> GetEmailConfirmationByUser(Guid id);
    }
}