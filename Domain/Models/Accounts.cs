using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Accounts
    {
        public string Account { get; set; } = string.Empty;
        [Key]
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public Currencies Currency { get; set; }
        public decimal Balance { get; set; }    

    }
}