using Domain.Interfaces;
using Domain.Models;

namespace Service
{
    public class PayService : IPayService
    {
        private readonly IAccountService accountService;

        public PayService(IAccountService accountService)
        {
            this.accountService = accountService;

        }

        public async Task<bool> PayToAccount(PayToAccountModel payTo)
        {
            var AccountFrom = await accountService.GetAccount(payTo.AccountFrom);
            var AccountTo = await accountService.GetAccount(payTo.AccountTo);

            if (AccountFrom == null || AccountTo == null)
                return false;

            if (AccountFrom.Balance<payTo.Value)
                return false;

            accountService.Notification += Notify;

            await accountService.PayToAccount(payTo.AccountFrom, payTo.AccountTo, payTo.Value);

            return true;
        }

        void Notify(IAccountService sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }  

    }
}
