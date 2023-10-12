using Application.DTOs.TamerManagement;

namespace Application.Interfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<TitleDTO>> GetTitles();
        Task<string> CreateTitle(TitleDTO titleDTO);
    }
}