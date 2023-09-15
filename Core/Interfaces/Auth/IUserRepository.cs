using System.Linq.Expressions;
using Core.Entities.Auth;
using Core.Interfaces.Base;

namespace Core.Interfaces.Auth
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUser(string username);

        Task<bool> UserVerify(Expression<Func<User, bool>> predicate);
    }
}