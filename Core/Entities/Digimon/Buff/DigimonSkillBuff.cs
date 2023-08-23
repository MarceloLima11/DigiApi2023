using Core.Common;
using Core.Validations;

namespace Core.Entities.Digimon.Buff
{
    public class DigimonSkillBuff : BaseEntity
    {
        public DigimonSkillBuff(int id, string name, string description, string activationPercentage)
        {
            DomainException.When(id < 0, "Valor de id inválido.");
            Id = id;

            ValidateSkillBuff(name, description, activationPercentage);
        }

        public DigimonSkillBuff(string name, string description, string activationPercentage)
        {
            ValidateSkillBuff(name, description, activationPercentage);
        }

        public string ActivationPercentage { get; set; }

        public void ValidateSkillBuff(string name, string description, string activationPercentage)
        {
            DomainException.When(String.IsNullOrWhiteSpace(name), "Nome inválido.");

            DomainException.When(String.IsNullOrWhiteSpace(description), "Description inválido.");

            DomainException.When(String.IsNullOrWhiteSpace(activationPercentage), "Activation Percentage inválido.");

            Name = name;
            Description = description;
            ActivationPercentage = activationPercentage;
        }
    }
}