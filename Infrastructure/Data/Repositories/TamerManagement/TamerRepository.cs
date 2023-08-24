using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;
using Core.Interfaces;
using Core.Interfaces.TamerManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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