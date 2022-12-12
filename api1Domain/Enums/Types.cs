using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;


namespace api1Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum Types
    {
        [EnumMember(Value = "string")]
        String = 0,
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
        List,
        [EnumMember(Value ="date")]
        DateTime,
    }

}
