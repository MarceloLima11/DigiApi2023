using Core.Entities.Tamer;

namespace Application.Interfaces
{
    public interface ITamerService
    {
        Task<List<Tamer>> GetTamers();
    }
}