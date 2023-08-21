using Core.Common;
using Core.Enums;

namespace Core.Entities.Digimon
{
    public class DigimonSkill : BaseEntity
    {
        public ElementalAttribute Attribute { get; set; }
        public int CoolDown { get; set; }
        public int DSConsumed { get; set; }
        public int NecessarySkillPoint { get; set; }
        public float AnimationTime { get; set; }
    }
}