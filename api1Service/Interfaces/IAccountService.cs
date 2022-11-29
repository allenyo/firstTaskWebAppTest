using api1Domain.Models;

namespace api1Service
{
    public interface IAccountService
    {
        Task<bool> AddAccount(Accounts accounts);
        Task<object?> GetBalance(string account);
        Task<object?> GetAll();
    }
}
