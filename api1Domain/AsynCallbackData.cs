namespace Models
{
    public class AsyncCallbackData
    {
        public CallbackType CallbackType { get; set; }

        public string Value { get; set; }

        public CallbackResultType CallbackResultType { get; set; } = CallbackResultType.Successed;

    }
}
