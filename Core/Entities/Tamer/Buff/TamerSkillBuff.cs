using Core.Enums;
using Core.Validations;

namespace Core.Entities.Tamer.Buff
{
    public class TamerSkillBuff
    {
        public TamerSkillBuff() { }

        public TamerSkillBuff(string name, DigimonAttribute firstBuff, DigimonAttribute seccondBuff)
        {
            ValidateTamerSkillBuff(name, firstBuff, seccondBuff);
        }

        public TamerSkillBuff(int id, string name, DigimonAttribute firstBuff, DigimonAttribute seccondBuff)
        {
            DomainException.When(id < 0, "Valor de id inválido.");
            this.Id = id;

            ValidateTamerSkillBuff(name, firstBuff, seccondBuff);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DigimonAttribute FirstBuffAttribute { get; set; }
        public DigimonAttribute SeccondBuffAttribute { get; set; }

        public ICollection<TamerSkill> TamerSkills { get; set; }

        private void ValidateTamerSkillBuff(string name, DigimonAttribute firstBuff, DigimonAttribute seccondBuff)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            Name = name;
            FirstBuffAttribute = firstBuff;
            SeccondBuffAttribute = seccondBuff;
        }
    }
}