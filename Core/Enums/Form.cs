using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum Form
    {
        [EnumDataType(typeof(int))]
        Rookie,
        [EnumDataType(typeof(int))]
        Champion,
        [EnumDataType(typeof(int))]
        Ultimate,
        [EnumDataType(typeof(int))]
        Mega,
        [EnumDataType(typeof(int))]
        BurstMode
    }
}