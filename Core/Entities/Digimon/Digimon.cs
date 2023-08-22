using Core.Common;
using Core.Enums;
using Attribute = Core.Enums.Attribute;

namespace Core.Entities.Digimon;

public sealed class Digimon : CharacterEntity
{
    public float AS { get; set; }
    public string CT { get; set; }
    public int HT { get; set; }
    public string EV { get; set; }
    public Evolution Form { get; set; }
    public Attribute Attribute { get; set; }
    public ElementalAttribute ElementalAttribute { get; set; }
    public ICollection<Digimon>? Evolutions { get; set; }
    public ICollection<Family> Families { get; set; }

    public ICollection<DigimonSkill> Skills { get; set; }
}
