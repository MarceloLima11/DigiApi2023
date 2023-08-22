using Core.Common;
using Core.Entities.Tamer.Buff;

namespace Core.Entities.Tamer
{
    public sealed class TamerSkill : BaseEntity
    {
        public int CoolDown { get; set; }
        public int TamerId { get; set; }
        public Tamer Tamer { get; set; }

        public int TamerSkillBuffId { get; set; }
        public TamerSkillBuff TamerSkillBuff { get; set; }
    }
}