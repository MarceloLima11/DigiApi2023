using Core.Validations;
using Core.Entities.Intermediate;

namespace Core.Entities.Digimon
{
    public class Riding
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<DigimonRidingIntermediate> Digimons { get; set; }

        private void ValidateRiding(string name, string description)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválido.");

            Name = name;
            Description = description;
        }
    }
}