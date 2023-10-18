using Core.Enums;

namespace Application.DTOs.TamerManagement
{
    public record SealDTO(SealLevel Level, string Abilitie, string Buff, int DigimonId);
}