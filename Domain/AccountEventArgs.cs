namespace Domain
{
    public class AccountEventArgs : EventArgs
    {
        public decimal Sum { get; }
        public string Message { get; }
        public string Account { get; }

        public AccountEventArgs(string message, decimal sum, string account)
        {
            Sum = sum;
            Message = message;
            Account = account;

        }

    }
}