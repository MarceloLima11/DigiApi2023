using Core.Common;

namespace Core.Entities.Tamer
{
    public sealed class Tamer : CharacterEntity
    {
        public int TamerSkillId { get; set; }
        public TamerSkill TamerSkill { get; set; }
    }
}