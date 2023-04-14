using System.Text.Json;

namespace Models
{
    public abstract class AsyncObject
    {
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public T FromJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
