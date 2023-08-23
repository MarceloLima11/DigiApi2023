using Core.Entities.Tamer;

namespace Core.Interfaces
{
    public interface ITamerRepository
    {
        Task<List<Tamer>> GetTamers();
    }
}