using Core.Common;
using Core.Enums;

namespace Core.Entities.Digimon;

public sealed class Digimon : CharacterEntity
{
    public float AS { get; set; }
    public string CT { get; set; }
    public int HT { get; set; }
    public string EV { get; set; }
    public Evolution Form { get; set; }
    public Enums.Attribute Attribute { get; set; }
    public ICollection<Digimon> Evolutions { get; set; }
    public ICollection<DigimonSkill> Skills { get; set; }
    public ICollection<Family> Families { get; set; }
}
