using Core.Entities.Item;
using Core.Interfaces.ItemManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.ItemManagement
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}