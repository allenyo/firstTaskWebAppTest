namespace api1Domain.Models
{
    public class Accounts
    {
        public string Account { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Balance { get; set; }    

    }
}