using Core.Common;
using Core.Entities.Intermediate;
using Core.Validations;

namespace Core.Entities.Digimon
{
    public class Riding : BaseEntity
    {
        public Riding(int id, string name, string description)
        {
            DomainException.When(id < 0, "Valor de id inválido.");

            Id = id;
            ValidateRiding(name, description);
        }

        public Riding(string name, string description)
        {
            ValidateRiding(name, description);
        }

        public ICollection<DigimonRidingIntermediate> Digimons { get; set; }

        private void ValidateRiding(string name, string description)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválido.");

            name = Name;
            description = Description;
        }
    }
}