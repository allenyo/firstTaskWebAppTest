using api1Domain.Models;

namespace api1Service
{
    public class AccountService : IAccountService
    {
        private readonly RequestManager _requestManager;
        private readonly string BaseUrl = "https://localhost:7234/api/account/";

        public AccountService(RequestManager requestManager) 
        { 
            _requestManager = requestManager;
        }

        public async Task<bool> AddAccount(Accounts accounts)
        {
            await _requestManager.Request($"{BaseUrl}AddAccount", HttpMethod.Post, accounts);
            return _requestManager.Success;
        }

        public async Task<object?> GetBalance(string account)
        {
            await _requestManager.Request($"{BaseUrl}getbalance/?account={account}", HttpMethod.Get);
            return _requestManager?.Data;
        }

        public async Task<object?> GetAll()
        {
            await _requestManager.Request($"{BaseUrl}getall", HttpMethod.Get);
            return _requestManager?.Data;
        }
    }
}

