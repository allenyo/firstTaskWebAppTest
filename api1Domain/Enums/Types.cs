using System.Runtime.Serialization;

namespace api1Domain.Enums
{
    public enum Types
    {
        None,
        [EnumMember(Value = "string")]
        String,
        [EnumMember(Value = "object")]
        Object,
        [EnumMember(Value = "arraylist")]
        ArrayList,
        [EnumMember(Value = "bool")]
        Bool,
        [EnumMember(Value = "decimal")]
        Decimal,
        [EnumMember(Value = "sbyte")]
        Sbyte,
        [EnumMember(Value = "byte")]
        Byte,
        [EnumMember(Value = "short")]
        Short,
        [EnumMember(Value = "ushort")]
        Ushort,
        [EnumMember(Value = "int")]
        Int,
        [EnumMember(Value = "uint")]
        Uint,
        [EnumMember(Value = "long")]
        Long,
        [EnumMember(Value = "ulong")]
        Ulong,
        [EnumMember(Value = "char")]
        Char,
        [EnumMember(Value = "float")]
        Float,
        [EnumMember(Value = "double")]
        Double,
        [EnumMember(Value = "dictionary")]
        Dictionary,
        [EnumMember(Value = "list")]
        List
    }

}
