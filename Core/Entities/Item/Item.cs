using Core.Enums;
using Core.Common;
using Core.Validations;
using Core.Entities.Item.Category;

namespace Core.Entities.Item
{
    public class Item : BaseEntity
    {
        public Item(int id, string name, string description, ClassItem classItem, int typeId)
        {
            DomainException.When(id < 0, "Valor de id inválido.");

            Id = id;
            ValidateItem(name, description, classItem, typeId);
        }

        public Item(string name, string description, ClassItem classItem, int typeId)
        { ValidateItem(name, description, classItem, typeId); }

        public ClassItem ClassItem { get; set; }

        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        private void ValidateItem(string name, string description, ClassItem classItem, int typeId)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválida.");

            DomainException.When(!Enum.IsDefined(typeof(ClassItem), classItem), "Classe de item inválida.");

            DomainException.When(typeId < 0, "Tipo de item inválido, é obrigatório que o item tenha um tipo.");

            Name = name;
            Description = description;
            ClassItem = classItem;
            ItemTypeId = typeId;
        }
    }
}