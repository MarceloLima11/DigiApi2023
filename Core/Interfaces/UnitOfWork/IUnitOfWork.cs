using Core.Interfaces.DigimonManagement;
using Core.Interfaces.TamerManagement;

namespace Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDigimonRepository DigimonRepository { get; }
        IDigimonSkillRepository DigimonSkillRepository { get; }
        IDigimonSkillBuffRepository DigimonSkillBuffRepository { get; }
        IEvolutionItemRepository EvolutionItemRepository { get; }
        IDigimonEvolutionItemRepository DigimonEvolutionItemRepository { get; }
        IFamilyRepository FamilyRepository { get; }
        IRidingRepository RidingRepository { get; }

        IDigimonFamilyRepository DigimonFamilyRepository { get; }
        IDigimonRidingRepository DigimonRidingRepository { get; }

        ITamerRepository TamerRepository { get; }
        ITamerSkillRepository TamerSkillRepository { get; }
        ITamerSkillBuffRepository TamerSkillBuffRepository { get; }
        Task Commit();
    }
}