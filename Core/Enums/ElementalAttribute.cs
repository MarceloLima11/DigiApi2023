using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum ElementalAttribute
    {
        [EnumDataType(typeof(int))]
        Fire,
        [EnumDataType(typeof(int))]
        Light,
        [EnumDataType(typeof(int))]
        Steel,
        [EnumDataType(typeof(int))]
        Wind,
        [EnumDataType(typeof(int))]
        Ice,
        [EnumDataType(typeof(int))]
        Neutral,
        [EnumDataType(typeof(int))]
        Thunder,
        [EnumDataType(typeof(int))]
        Wood,
        [EnumDataType(typeof(int))]
        Land,
        [EnumDataType(typeof(int))]
        PitchBlack,
        [EnumDataType(typeof(int))]
        Water
    }
}