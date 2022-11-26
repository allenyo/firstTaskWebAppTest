using Domain;
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

            accountService.Notification += Notify;

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

            var thread1 = new Thread(RemoveEvent);
   /*         var thread2 = new Thread(new ParameterizedThreadStart(Pay));*/

            thread1.Start();
    /*        thread2.Start(payTo);*/
          


       

            return true;
        }

        void Notify(object? sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }  


         void RemoveEvent()
        {
            accountService.Notification -= Notify;

        }

     /*  async void Pay(object? PayTo)
        {
            if (PayTo != null)
            {
                if (PayTo is PayToAccountModel payTo)
                    await accountService.PayToAccount(payTo.AccountFrom, payTo.AccountTo, payTo.Value);
            }  
           
        }*/
    }
}
