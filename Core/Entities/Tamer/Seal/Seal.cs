using Core.Enums;
using Core.Validations;

namespace Core.Entities.Tamer.Seal
{
    public class Seal
    {
        private readonly string[] Abilities = { "AT", "CT", "HT", "HP", "DS", "DE", "BL", "EV" };

        public int Id { get; set; }
        public SealLevel Level { get; set; }
        public string Abilitie { get; set; }
        public string Buff { get; set; }

        public int DigimonId { get; set; }
        public Digimon.Digimon Digimon { get; set; }

        public Seal(SealLevel level, string abilitie, string buff, int digimonId)
        {
            ValidateSeal(level, abilitie, buff, digimonId);
        }

        private void ValidateSeal(SealLevel level, string abilitie, string buff, int digimonId)
        {
            DomainException.When(!Enum.IsDefined(typeof(SealLevel), level), "Level do seal inválido.");

            DomainException.When(String.IsNullOrEmpty(abilitie), "Habilidade de seal inválida.");

            DomainException.When(!Abilities.Contains(abilitie.ToUpper().Trim()), "Habilidade de seal inválida.");

            DomainException.When(String.IsNullOrEmpty(buff), "Buff inválido.");

            DomainException.When(digimonId < 0, "Id de digimon inválido.");
        }
    }
}