using Core.Entities.Auth;
using Core.Interfaces.Base;

namespace Core.Interfaces.Auth
{
    public interface IPasswordResetRepository : IRepositoryBase<PasswordReset>
    {
        Task<PasswordReset> GetByUserId(Guid id);
    }
}