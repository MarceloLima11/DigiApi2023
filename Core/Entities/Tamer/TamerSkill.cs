using Core.Common;
using Core.Entities.Tamer.Buff;
using Core.Validations;

namespace Core.Entities.Tamer
{
    public sealed class TamerSkill : BaseEntity
    {
        public TamerSkill() { }

        public TamerSkill(string name, string description, int cd, int buffId)
        {
            ValidateTamerSkill(name, description, cd, buffId);
        }

        public TamerSkill(int id, string name, string description, int cd, int buffId)
        {
            DomainException.When(id < 0, "Valor de id inválido.");
            this.Id = id;

            ValidateTamerSkill(name, description, cd, buffId);
        }

        public int CoolDown { get; set; }
        public int TamerSkillBuffId { get; set; }
        public TamerSkillBuff TamerSkillBuff { get; set; }

        private void ValidateTamerSkill(string name, string description, int cd, int buffId)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválida.");

            DomainException.When(cd < 0, "CoolDown inválido.");

            DomainException.When(buffId < 0, "É obrigatório que a skill possua um buff.");

            Name = name;
            Description = description;
            CoolDown = cd;
            TamerSkillBuffId = buffId;
        }
    }
}