using Core.Entities.Digimon.Buff;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonSkillBuffRepository : RepositoryBase<DigimonSkillBuff>, IDigimonSkillBuffRepository
    {
        public DigimonSkillBuffRepository(ApplicationDbContext context) : base(context)
        { }
    }
}