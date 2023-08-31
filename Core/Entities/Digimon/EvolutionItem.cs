using System.Diagnostics.Contracts;
using Core.Entities.Intermediate;
using Core.Validations;

namespace Core.Entities.Digimon
{
    public class EvolutionItem
    {
        public EvolutionItem(int id, string name, int quantity)
        {
            DomainException.When(id < 0, "Valor de id inválido.");

            Id = id;
            ValidateEvolutionItem(name, quantity);
        }

        public EvolutionItem(string name, int quantity)
        {
            ValidateEvolutionItem(name, quantity);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public ICollection<DigimonEvolutionItemIntermediate> Digimons { get; set; }

        private void ValidateEvolutionItem(string name, int quantity)
        {
            DomainException.When(String.IsNullOrWhiteSpace(name), "Nome inválido.");

            Name = name;
            Quantity = quantity;
        }
    }
}