using Core.Entities.Tamer.Title;
using Infrastructure.Data.Context;
using Core.Interfaces.TamerManagement;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.TamerManagement
{
    public class TitleRepository : RepositoryBase<Title>, ITitleRepository
    {
        public TitleRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}