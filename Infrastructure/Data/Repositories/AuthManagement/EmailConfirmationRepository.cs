using Core.Entities.Auth;
using Core.Interfaces.Auth;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.AuthManagement
{
    public class EmailConfirmationRepository : RepositoryBase<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}