using Core.Entities.Auth;
using Core.Interfaces.Auth;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.AuthManagement
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(ApplicationDbContext _context) : base(context: _context)
        { }

        public async Task<PasswordReset> GetByUserId(Guid id) => await _dbSet.FirstOrDefaultAsync(x => x.UserId == id);
    }
}