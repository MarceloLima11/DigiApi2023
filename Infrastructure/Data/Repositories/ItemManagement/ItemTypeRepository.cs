using Core.Entities.Item.Category;
using Core.Interfaces.ItemManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.ItemManagement
{
    public class ItemTypeRepository : RepositoryBase<ItemType>, IItemTypeRepository
    {
        public ItemTypeRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}