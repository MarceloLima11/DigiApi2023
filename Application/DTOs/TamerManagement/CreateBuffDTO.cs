using Core.Enums;

namespace Application.DTOs.TamerManagement
{
    public class CreateBuffDTO
    {
        public string Name { get; set; }
        public DigimonAttribute FirstBuffAttribute { get; set; }
        public DigimonAttribute SeccondBuffAttribute { get; set; }
    }
}