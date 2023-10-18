using Core.Entities.Auth;
using Core.Interfaces.Auth;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.AuthManagement
{
    public class EmailConfirmationRepository : RepositoryBase<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<EmailConfirmation> GetEmailConfirmationByUser(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}