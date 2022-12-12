using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum Currencies 
    {
        [EnumMember(Value = "AMD")]
        [Description("Armenian dram")]
        AMD = 0,
        [EnumMember(Value = "USD")]
        [Description("American dollar")]
        USD = 1,
        [EnumMember(Value = "EUR")]
        [Description("European Euro")]
        EUR = 2,
        [EnumMember(Value = "RUB")]
        [Description("Russian ruble")]
        RUB = 3,

    }
}
