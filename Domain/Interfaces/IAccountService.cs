using Data;

namespace Domain.Interfaces
{
    public interface IAccountService
    {
        Task<bool> AddAccount(Accounts accounts);
        Task<object?> GetAll();
        Task<object?> GetBalance(string account);
        Task<object?> GetAccounts(int id);   
    }
}
