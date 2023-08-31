using Core.Entities.Intermediate;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonEvolutionItemRepository : RepositoryBase<DigimonEvolutionItemIntermediate>, IDigimonEvolutionItemRepository
    {
        public DigimonEvolutionItemRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<IEnumerable<DigimonEvolutionItemIntermediate>> GetDigimonEvolutionItemIntermediatesByDigimon(int id)
        {
            return await _dbSet.Where(x => x.DigimonId == id).ToListAsync();
        }
    }
}