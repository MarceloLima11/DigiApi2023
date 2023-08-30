using Core.Enums;

namespace Application.DTOs.TamerManagement
{
    public class BuffDTO
    {
        public string Name { get; set; }
        public DigimonAttribute FirstBuffAttribute { get; set; }
        public DigimonAttribute SeccondBuffAttribute { get; set; }
    }
}