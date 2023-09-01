namespace Application.DTOs.ItemManagement
{
    public class CreateItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}