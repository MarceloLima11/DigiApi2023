using Core.Entities.Digimon;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonSkillRepository : RepositoryBase<DigimonSkill>, IDigimonSkillRepository
    {
        public DigimonSkillRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<DigimonSkill> GetSkillByDigimon(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DigimonId == id);
        }
    }
}