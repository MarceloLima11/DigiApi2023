using Core.Common.Intefaces;

namespace Core.Common
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}