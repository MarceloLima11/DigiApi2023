using Core.Entities.Intermediate;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonItemRepository : RepositoryBase<DigimonItemIntermediate>, IDigimonItemRepository
    {
        public DigimonItemRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<IEnumerable<DigimonItemIntermediate>> GetDigimonItemIntermediatesByDigimon(int id)
        {
            return await _dbSet.Where(x => x.DigimonId == id).ToListAsync();
        }
    }
}