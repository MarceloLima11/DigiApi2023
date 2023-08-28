using Core.Entities.Digimon;
using Core.Interfaces.Base;

namespace Core.Interfaces.DigimonManagement
{
    public interface IDigimonSkillRepository : IRepositoryBase<DigimonSkill>
    {
        Task<DigimonSkill> GetSkillByDigimon(int id);
    }
}