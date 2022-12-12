using api1Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace api1Domain.Models
{
    public class ConvertRequestModel
    {
        public Types InType { get; set; }
        public Types OutType { get; set; }
        public object Value { get; set; } = null!;
    }
}
