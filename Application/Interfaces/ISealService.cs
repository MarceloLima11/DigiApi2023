using Application.DTOs.TamerManagement;

namespace Application.Interfaces
{
    public interface ISealService
    {
        Task<IEnumerable<SealDTO>> GetSeals();
    }
}