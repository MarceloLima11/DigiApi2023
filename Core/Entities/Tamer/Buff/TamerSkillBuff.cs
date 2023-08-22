namespace Core.Entities.Tamer.Buff
{
    public class TamerSkillBuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Attribute FirstBuffAttribute { get; set; }
        public Attribute SeccondBuffAttribute { get; set; }

        public ICollection<TamerSkill> TamerSkills { get; set; }
    }
}