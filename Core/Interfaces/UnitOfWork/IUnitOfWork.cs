using Core.Interfaces.Auth;
using Core.Interfaces.DigimonManagement;
using Core.Interfaces.ItemManagement;
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
        IDigimonItemRepository DigimonItemRepository { get; }

        IItemRepository ItemRepository { get; }
        IItemTypeRepository ItemTypeRepository { get; }

        ITamerRepository TamerRepository { get; }
        ITamerSkillRepository TamerSkillRepository { get; }
        ITamerSkillBuffRepository TamerSkillBuffRepository { get; }

        IUserRepository UserRepository { get; }
        IEmailConfirmationRepository EmailConfirmationRepository { get; }

        Task Commit();
    }
}