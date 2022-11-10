using Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly RepositoryDBContext _dbContext;

        public AccountService(RepositoryDBContext repositoryDBContext)
        {
            _dbContext = repositoryDBContext;
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
            return await _dbContext.Accounts.AsNoTracking().Where(i => i.UserId == userId).ToListAsync();
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
            Account.Balance = balance;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
