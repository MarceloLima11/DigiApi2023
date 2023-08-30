namespace Application.DTOs.TamerManagement
{
    public class SkillDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoolDown { get; set; }
        public BuffDTO Buff { get; set; }
    }
}