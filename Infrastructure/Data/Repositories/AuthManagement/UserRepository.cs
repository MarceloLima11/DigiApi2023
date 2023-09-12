using Core.Entities.Auth;
using Core.Interfaces.Auth;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.AuthManagement
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<User> GetUser(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}