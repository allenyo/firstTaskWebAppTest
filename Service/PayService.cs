using Domain.Interfaces;
using Domain.Models;

namespace Service
{
    public class PayService : IPayService
    {
        private readonly IAccountService accountService;
        private readonly IExchangeService exchangeService;

        public PayService(IExchangeService exchangeService, IAccountService accountService)
        {
            this.exchangeService = exchangeService;
            this.accountService = accountService;

        }

        public async Task<bool> PayToAccount(PayToAccountModel payTo)
        {
            var AccountFrom = await accountService.GetAccount(payTo.AccountFrom);
            var AccountTo = await accountService.GetAccount(payTo.AccountTo);
            decimal valueTo;
            decimal valueFrom;

            if (AccountFrom == null || AccountTo == null)
                return false;

            if (AccountFrom.Balance<payTo.Value)
                return false;

            if (AccountFrom.Currency != AccountTo.Currency)
            {
                var ExchangeRequest = new ExchangeRequestModel { Value = payTo.Value, CurrencyeOut = AccountTo.Currency, CurrencyIn = AccountFrom.Currency };

                if (decimal.TryParse(await exchangeService.Exchange(ExchangeRequest), out decimal ValueTo))
                {
                    valueTo = AccountTo.Balance + ValueTo;
                } else
                {
                    return false;
                }
            }else
            {
                valueTo = AccountTo.Balance + payTo.Value;
            }
            
            valueFrom = AccountFrom.Balance - payTo.Value;


            await accountService.ChangeBalance(AccountFrom.Account, valueFrom);
            await accountService.ChangeBalance(AccountTo.Account, valueTo);


            return true;
        }
    }
}
