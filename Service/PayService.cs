using Domain;
using Domain.Models;

namespace Service
{
    public class PayService : IPayService, IDisposable
    {
        private readonly IAccountService accountService;

        public PayService(IAccountService accountService)
        {
            this.accountService = accountService;     

            accountService.Notification += Notify;

        }

        public void Dispose()
        {
           
        }

        public async Task<bool> PayToAccount(PayToAccountModel payTo)
        {
            var AccountFrom = await accountService.GetAccount(payTo.AccountFrom);
            var AccountTo = await accountService.GetAccount(payTo.AccountTo);

            if (AccountFrom == null || AccountTo == null)
                return false;

            if (AccountFrom.Balance<payTo.Value)
                return false;

          await accountService.PayToAccount(payTo.AccountFrom, payTo.AccountTo, payTo.Value);

            return true;
        }

        void Notify(object? sender, AccountEventArgs e)
        {
          
            Console.WriteLine(e.Message);
        }  

    }
}
