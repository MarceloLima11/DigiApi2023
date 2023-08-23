using Core.Common;
using Core.Entities.Intermediate;
using Core.Validations;

namespace Core.Entities.Digimon
{
    public class Family : BaseEntity
    {
        public Family(int id, string name, string description, string abbreviation)
        {
            DomainException.When(id < 0, "Valor de id inválido.");
            Id = id;

            ValidateFamily(name, description, abbreviation);
        }

        public Family(string name, string description, string abbreviation)
        {
            ValidateFamily(name, description, abbreviation);
        }

        public string Abbreviation { get; set; }
        public ICollection<DigimonFamilyIntermediate> Digimons { get; set; }

        private void ValidateFamily(string name, string description, string abbreviation)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Description inválido.");

            DomainException.When(String.IsNullOrEmpty(abbreviation), "Abbreviation inválido.");

            Name = name;
            Description = description;
            Abbreviation = abbreviation;
        }
    }
}