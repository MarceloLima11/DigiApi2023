using Core.Interfaces.DigimonManagement;
using Core.Interfaces.TamerManagement;

namespace Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDigimonRepository DigimonRepository { get; }
        IDigimonSkillRepository DigimonSkillRepository { get; }
        IDigimonSkillBuffRepository DigimonSkillBuffRepository { get; }
        IFamilyRepository FamilyRepository { get; }

        IDigimonFamilyRepository DigimonFamilyRepository { get; }

        ITamerRepository TamerRepository { get; }
        ITamerSkillRepository TamerSkillRepository { get; }
        ITamerSkillBuffRepository TamerSkillBuffRepository { get; }
        Task Commit();
    }
}