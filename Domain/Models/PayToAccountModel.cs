namespace Domain.Models
{
    public class PayToAccountModel
    {
        public decimal Value { get; set; }  
        public string AccountFrom { get; set; } = string.Empty;
        public string AccountTo { get; set; } = string.Empty;
    }
}
