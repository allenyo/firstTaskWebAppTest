using Domain.Enums;
using Domain.Models;
using Domain.values;

namespace Service
{
    public class ExchangeService : IExchangeService
    {
        public async Task<string> Exchange(ExchangeRequestModel requestModel)
        {
            var currencyOut = requestModel.CurrencyeOut;
            var currencyIn = requestModel.CurrencyIn;
            var value = requestModel.Value;

            if (currencyOut.Equals(Currencies.AMD)) 
            {
                switch (currencyIn)
                {
                    case Currencies.USD:
                        {
                           if (decimal.TryParse(ExchangeRatesValues.USD.Split(" ")[0], out decimal v))
                            return (value * v).ToString() + " AMD";
                        } break;

                    case Currencies.RUB:
                        {
                            if (decimal.TryParse(ExchangeRatesValues.RUB.Split(" ")[0], out decimal v))
                                return (value * v).ToString() + " AMD";
                        } break;
                    case Currencies.EUR:
                        {
                            if (decimal.TryParse(ExchangeRatesValues.EUR.Split(" ")[0], out decimal v))
                                return (value * v).ToString() + " AMD";
                        } break;

                    default: throw new ArgumentException("wrong currency");
                } 
          
            } else
            {
                if (currencyOut.Equals(Currencies.USD))
                {
                    switch (currencyIn)
                    {
                        case Currencies.AMD:
                            {
                                if (decimal.TryParse(ExchangeRatesValues.USD.Split(" ")[0], out decimal v))
                                    return (value / v).ToString() + " USD";
                            } break;
                        case Currencies.RUB:
                            {
                                if (decimal.TryParse(ExchangeRatesValues.RUB.Split(" ")[0], out decimal v))
                                {
                                    if (decimal.TryParse(ExchangeRatesValues.USD.Split(" ")[0], out decimal vr))
                                        return ((value * v) / vr).ToString() + " USD";

                                }                                   
                            } break;
                        case Currencies.EUR:
                            {
                                if (decimal.TryParse(ExchangeRatesValues.EUR.Split(" ")[0], out decimal v))
                                {
                                    if (decimal.TryParse(ExchangeRatesValues.USD.Split(" ")[0], out decimal ve))
                                        return ((value * v) / ve).ToString() + " EUR";
                                }
                            } break;
                        default: throw new ArgumentException("wrong currency");
                    } 

                } else
                {
                    if (currencyOut.Equals(Currencies.RUB))
                    {
                        switch (currencyIn)
                        {
                            case Currencies.AMD:
                                {
                                    if (decimal.TryParse(ExchangeRatesValues.RUB.Split(" ")[0], out decimal v))
                                        return (value / v).ToString() + " RUB";
                                } break;
                            case Currencies.USD:
                                {
                                    if (decimal.TryParse(ExchangeRatesValues.USD.Split(" ")[0], out decimal v))
                                    {
                                        if (decimal.TryParse(ExchangeRatesValues.RUB.Split(" ")[0], out decimal vr))
                                            return ((value / v) * vr).ToString() + " RUB";
                                    }
                                }break;
                            case Currencies.EUR:
                                {
                                    if (decimal.TryParse(ExchangeRatesValues.EUR.Split(" ")[0], out decimal v))
                                    {
                                        if (decimal.TryParse(ExchangeRatesValues.RUB.Split(" ")[0], out decimal vr))
                                            return ((value / v) * vr).ToString() + " RUB";
                                    }break;
                                }
                            default: throw new ArgumentException("wrong currency");
                        }
                    } else
                    {
                        if (currencyOut.Equals(Currencies.EUR))
                        {
                            switch (currencyIn) 
                            {
                                case Currencies.AMD:
                                    {
                                        if (decimal.TryParse(ExchangeRatesValues.EUR.Split(" ")[0], out decimal v))
                                            return (value / v).ToString() + " EUR";
                                    }
                                    break;
                                case Currencies.USD:
                                    {
                                        if (decimal.TryParse(ExchangeRatesValues.USD.Split(" ")[0], out decimal v))
                                        {
                                            if (decimal.TryParse(ExchangeRatesValues.EUR.Split(" ")[0], out decimal vu))
                                                return (value / v * vu).ToString() + " EUR";
                                        }
                                    }break;
                                case Currencies.RUB:
                                    {
                                        if (decimal.TryParse(ExchangeRatesValues.RUB.Split(" ")[0], out decimal v))
                                        {
                                            if (decimal.TryParse(ExchangeRatesValues.EUR.Split(" ")[0], out decimal ve))
                                                return (value * v / ve).ToString() + " EUR";
                                        }
                                    } break;
                                default: throw new ArgumentException(" wrong currency");
                            }

                        } else
                        {
                            throw new Exception("Somwthing Wrong");
                        }

                    }
                }

            }
            throw new Exception("Something wrong");
        }
    }
}
