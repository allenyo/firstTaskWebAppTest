using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{
    public class StackConverter<TStack, TItem> : JsonConverter<TStack> where TStack : Stack<TItem>, new()
    {
        public override TStack Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<TItem> list = JsonSerializer.Deserialize<List<TItem>>(ref reader, options);
            if (list == null)
            {
                return null;
            }

            TStack val = ((typeToConvert == typeof(Stack<TItem>)) ? ((TStack)new Stack<TItem>(list.Count)) : new TStack());
            for (int num = list.Count - 1; num >= 0; num--)
            {
                val.Push(list[num]);
            }

            return val;
        }

        public override void Write(Utf8JsonWriter writer, TStack value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (TItem item in value)
            {
                JsonSerializer.Serialize(writer, item, options);
            }

            writer.WriteEndArray();
        }
    }
}