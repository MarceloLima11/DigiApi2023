using Core.Common.Intefaces;

namespace Core.Common;

public class CharacterEntity : BaseEntity, IStatus
{
    public int HP { get; set; }
    public int DS { get; set; }
    public int DE { get; set; }
    public int AT { get; set; }
}
