using Core.Interfaces.Base;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Base
{
    public class RepositoryBase<X> : IRepositoryBase<X> where X : class
    {
        protected readonly DbSet<X> _dbSet;

        public RepositoryBase(ApplicationDbContext context)
        { _dbSet = context.Set<X>(); }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public async Task<IEnumerable<X>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public void Delete(X entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<X> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(X entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(X entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}