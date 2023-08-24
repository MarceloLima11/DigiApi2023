using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum DigimonAttribute
    {
        [EnumDataType(typeof(int))]
        Data,
        [EnumDataType(typeof(int))]
        Vaccine,
        [EnumDataType(typeof(int))]
        Virus,
        [EnumDataType(typeof(int))]
        No,
        [EnumDataType(typeof(int))]
        Unknown
    }
}