
using Domain.Enums;

namespace Domain.Models
{
    public class ExchangeRequestModel
    {
        public decimal Value { get; set; }
        public Currencies CurrencyIn { get; set; }
        public Currencies CurrencyeOut { get; set; }
    }
}
