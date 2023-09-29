using Core.Entities.Auth;
using Core.Interfaces.Auth;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.AuthManagement
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(ApplicationDbContext _context) : base(context: _context)
        { }
    }
}