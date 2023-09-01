using Core.Common;
using Core.Validations;
using Core.Entities.Item.Category;
using Core.Entities.Intermediate;

namespace Core.Entities.Item
{
    public class Item : BaseEntity
    {
        public Item()
        { }

        public Item(int id, string name, string description, int typeId)
        {
            DomainException.When(id < 0, "Valor de id inválido.");

            Id = id;
            ValidateItem(name, description, typeId);
        }

        public Item(string name, string description, int typeId)
        { ValidateItem(name, description, typeId); }

        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        public ICollection<DigimonItemIntermediate> Digimons { get; set; }

        private void ValidateItem(string name, string description, int typeId)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválida.");

            DomainException.When(typeId < 0, "Tipo de item inválido, é obrigatório que o item tenha um tipo.");

            Name = name;
            Description = description;
            ItemTypeId = typeId;
        }
    }
}