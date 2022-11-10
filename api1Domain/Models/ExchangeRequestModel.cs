using api1Domain.Enums;

namespace api1Domain.Models
{
    public class ExchangeRequestModel
    {
        public decimal Value { get; set; }
        public Currencies CurrencyIn { get; set; }
        public Currencies CurrencyeOut { get; set; }
    }
}
