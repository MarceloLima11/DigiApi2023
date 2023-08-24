using Core.Entities.Digimon.Buff;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories
{
    public class DigimonSkillBuffRepository : RepositoryBase<DigimonSkillBuff>, IDigimonSkillBuffRepository
    {
        public DigimonSkillBuffRepository(ApplicationDbContext context) : base(context)
        { }
    }
}