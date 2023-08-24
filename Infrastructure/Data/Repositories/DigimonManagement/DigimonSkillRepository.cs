using Core.Entities.Digimon;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class DigimonSkillRepository : RepositoryBase<DigimonSkill>, IDigimonSkillRepository
    {
        public DigimonSkillRepository(ApplicationDbContext context) : base(context)
        { }
    }
}