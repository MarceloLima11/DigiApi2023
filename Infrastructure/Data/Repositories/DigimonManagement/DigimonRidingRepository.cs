using Core.Entities.Intermediate;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonRidingRepository : RepositoryBase<DigimonRidingIntermediate>, IDigimonRidingRepository
    {
        public DigimonRidingRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<IEnumerable<DigimonRidingIntermediate>> GetDigimonRidingIntermediatesByDigimon(int id)
            => await _dbSet.Where(x => x.DigimonId == id).ToListAsync();
    }
}