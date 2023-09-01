namespace Application.DTOs.TamerManagement
{
    public class TamerSkillDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoolDown { get; set; }
        public TamerBuffDTO Buff { get; set; }
    }
}