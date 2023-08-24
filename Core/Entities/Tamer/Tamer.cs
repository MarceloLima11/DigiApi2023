using Core.Common;
using Core.Validations;

namespace Core.Entities.Tamer
{
    public sealed class Tamer : CharacterEntity
    {
        public Tamer() { }

        public Tamer(string name, string description, int hp, int ds, int de, int at, int idSkill)
        {
            ValidateTamer(name, description, hp, ds, de, at, idSkill);
        }

        public Tamer(int id, string name, string description, int hp, int ds, int de, int at, int idSkill)
        {
            DomainException.When(id < 0, "Valor de id inválido.");

            Id = id;
            ValidateTamer(name, description, hp, ds, de, at, idSkill);
        }

        public int TamerSkillId { get; set; }
        public TamerSkill TamerSkill { get; set; }

        private void ValidateTamer(string name, string description, int hp, int ds, int de, int at, int skillId)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválida.");

            DomainException.When(hp <= 0, "HP inválido.");

            DomainException.When(ds <= 0, "DS inválido.");

            DomainException.When(de <= 0, "DE inválido.");

            DomainException.When(at <= 0, "AT inválido.");

            DomainException.When(skillId < 0, "É obrigatório que o Tamer possua uma skill!");

            HP = hp;
            DS = ds;
            DE = de;
            AT = at;
            Name = name;
            TamerSkillId = skillId;
            Description = description;
        }
    }
}