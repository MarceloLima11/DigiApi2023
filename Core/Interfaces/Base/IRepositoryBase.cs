namespace Core.Interfaces.Base
{
    public interface IRepositoryBase<X> where X : class
    {
        Task<X> GetById(int id);
        void Delete(int id);
        void Delete(X entity);
        void Add(X entity);
        void Update(X entity);
        Task<IEnumerable<X>> GetAll();
    }
}