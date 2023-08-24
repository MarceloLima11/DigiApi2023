namespace Application.DTOs.TamerManagement
{
    public class CreateSkillDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoolDown { get; set; }
        public CreateBuffDTO Buff { get; set; }
    }
}