using Data;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly RepositoryDBContext _dbContext;
        private readonly IUserService userService;
        private readonly IExchangeService exchangeService;

        public event EventHandler<AccountEventArgs>? Notification;

        public AccountService(RepositoryDBContext repositoryDBContext, IUserService userService, IExchangeService exchangeService)
        {
            _dbContext = repositoryDBContext;
            this.userService = userService;
            this.exchangeService = exchangeService;
        }

        public async Task<object?> GetAll()
        {
            return await _dbContext.Accounts.AsNoTracking().ToListAsync();
        }

        public async Task<bool> AddAccount(Accounts accounts)
        {
            await _dbContext.Accounts.AddAsync(accounts);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> GetBalance(string account)
        {
            var acc =  await _dbContext.Accounts.SingleOrDefaultAsync(n => n.Account == account);
            return acc?.Balance + " " + acc?.Currency;
        }

        public async Task<object?> GetAccounts(int userId)
        {
            return await _dbContext.Accounts.Where(i => i.UserId == userId).ToListAsync();
        } 
        
        public async Task<Accounts?> GetAccount(string account)
        {
            return await _dbContext.Accounts.AsNoTracking().SingleOrDefaultAsync(i => i.Account == account);
        }

        public async Task<bool> ChangeBalance(string account, decimal balance)
        {
          
            var Account = await _dbContext.Accounts.SingleOrDefaultAsync(i => i.Account == account);

            if (Account == null)
                return false;

            Notification?.Invoke(this, new AccountEventArgs($"{Account.Account} Account balance - {Account.Balance}", Account.Balance - balance, Account.Account));

            Account.Balance = balance;
          
            await _dbContext.SaveChangesAsync();  

            return true;
        }


        public async Task<bool> PayToAccount(string accountFrom, string accountTo, decimal value)
        {
            var AccountFrom = await _dbContext.Accounts.SingleOrDefaultAsync(i => i.Account == accountFrom);
            var AccountTo = await _dbContext.Accounts.SingleOrDefaultAsync(i => i.Account == accountTo);

            var userAccountFrom = await userService.GetUsers(AccountFrom!.UserId);
            var userAccountTo = await userService.GetUsers(AccountTo!.UserId);

            decimal valueTo;

            if (AccountFrom.Currency != AccountTo.Currency)
            {
                var ExchangeRequest = new ExchangeRequestModel
                {
                    Value = value,
                    CurrencyeOut = AccountTo.Currency,
                    CurrencyIn = AccountFrom.Currency
                };
                var ValueTo = await exchangeService.Exchange(ExchangeRequest);

                valueTo = decimal.Parse(ValueTo.Split(" ")[0]);

            }
            else
            {
                valueTo = value;
            }

            OnBalanceChanged(new AccountEventArgs($"Transaction from {AccountFrom.Account} " +
              $"({userAccountFrom!.FirstName} {userAccountFrom.LastName})\n" +
              $"Account balance - {AccountFrom.Balance} {AccountFrom.Currency}\n" +
              $"Withdrawn from account: {value} {AccountFrom.Currency}\n" +
              $"Balance {AccountFrom.Balance - value} {AccountFrom.Currency}  ", value, AccountFrom.Account));

            OnBalanceChanged(new AccountEventArgs($"Transaction to {AccountTo.Account} " +
                $"({userAccountTo!.FirstName} {userAccountTo.LastName})\n" +
                $"Account balance - {AccountTo.Balance} {AccountTo.Currency}\n" +
                $"Credited to account {AccountTo.Account}: {valueTo} {AccountTo.Currency}\n" +
                $"Balance {valueTo + AccountTo.Balance} {AccountTo.Currency}", valueTo, AccountTo.Account));
         
            AccountFrom.Balance -= value;
            AccountTo.Balance += valueTo;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        protected virtual void OnBalanceChanged(AccountEventArgs e)
        {
            /*EventHandler<AccountEventArgs>? temp = Volatile.Read(ref Notification);

             if (temp != null) temp(this, e);
 */
            Notification?.Invoke(this, e);
        }

    }
}
