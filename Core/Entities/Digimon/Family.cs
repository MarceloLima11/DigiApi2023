using Core.Common;
using Core.Entities.Intermediate;

namespace Core.Entities.Digimon
{
    public class Family : BaseEntity
    {
        public string Abbreviation { get; set; }
        public ICollection<DigimonFamilyIntermediate> Digimons { get; set; }
    }
}