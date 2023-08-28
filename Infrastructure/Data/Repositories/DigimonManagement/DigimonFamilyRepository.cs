using Core.Entities.Intermediate;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonFamilyRepository : RepositoryBase<DigimonFamilyIntermediate>, IDigimonFamilyRepository
    {
        public DigimonFamilyRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<IEnumerable<DigimonFamilyIntermediate>> GetDigimonFamilyIntermediatesByDigimon(int id)
        {
            return await _dbSet.Where(x => x.DigimonId == id).ToListAsync();
        }
    }
}