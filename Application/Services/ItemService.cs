using Application.DTOs.ItemManagement;
using Application.Interfaces;
using Core.Entities.Item;
using Core.Interfaces.UnitOfWork;

namespace Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unit;
        public ItemService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<string> CreateItem(CreateItemDTO itemDTO)
        {
            try
            {
                Item item = new(itemDTO.Name, itemDTO.Description, itemDTO.CategoryId);
                _unit.ItemRepository.Add(item);
                await _unit.Commit();

                return "Sucesso!";
            }
            catch
            { throw; }
        }
    }
}