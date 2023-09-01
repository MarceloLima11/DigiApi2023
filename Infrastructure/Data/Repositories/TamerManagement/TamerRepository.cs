using Core.Entities.Tamer;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.TamerManagement;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.TamerManagement
{
    public class TamerRepository : RepositoryBase<Tamer>, ITamerRepository
    {
        public TamerRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<Tamer> GetTamerAndSkill(int id)
        {
            return await _dbSet.Include(x => x.TamerSkill)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}