using Application.DTOs.ItemManagement;

namespace Application.Interfaces
{
    public interface IItemService
    {
        Task<string> CreateItem(CreateItemDTO itemDTO);
    }
}