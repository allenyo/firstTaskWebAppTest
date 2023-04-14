using System.Text.Json.Serialization;

namespace Models
{
    public class AsyncRequestData<T> : AsyncObject
    {
        [JsonConverter(typeof(StackConverter<AsyncCallbackData>))]
        public Stack<AsyncCallbackData> AsyncCallbacks { get; set; } = new Stack<AsyncCallbackData>();


        public string RequestId { get; set; }

        public string DeviceId { get; set; }

        public T Data { get; set; }
    }
}
