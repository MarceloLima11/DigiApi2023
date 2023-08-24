namespace Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDigimonRepository DigimonRepository { get; }
        IDigimonSkillRepository DigimonSkillRepository { get; }
        IDigimonSkillBuffRepository DigimonSkillBuffRepository { get; }
        IFamilyRepository FamilyRepository { get; }


        ITamerRepository TamerRepository { get; }
        ITamerSkillRepository TamerSkillRepository { get; }
        ITamerSkillBuffRepository TamerSkillBuffRepository { get; }

        Task Commit();
    }
}