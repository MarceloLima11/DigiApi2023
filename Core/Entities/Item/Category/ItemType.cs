using Core.Common;
using Core.Validations;

namespace Core.Entities.Item.Category
{
    public class ItemType : BaseEntity
    {
        public ItemType(int id, string name, string description)
        {
            DomainException.When(id < 0, "Valor de id inválido.");

            Id = id;
            ValidateItemType(name, description);
        }

        public ItemType(string name, string description)
        { ValidateItemType(name, description); }

        private void ValidateItemType(string name, string description)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválida.");

            Name = name;
            Description = description;
        }
    }
}