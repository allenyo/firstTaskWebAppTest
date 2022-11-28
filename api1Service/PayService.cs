using api1Domain.Interfaces;
using api1Domain.Models;

namespace api1Service
{
    public class PayService : IPayService
    { 
        private readonly RequestManager _requestManager;
        private readonly string BaseUrl = "https://localhost:7234/api/pay/";

        public PayService(RequestManager requestManager)
        {
            _requestManager = requestManager;
        }

        public async Task<bool> PayToAccount(PayToAccountModel payTo)
        {
            await _requestManager.Request($"{BaseUrl}paytoaccount", HttpMethod.Post, payTo);
            return _requestManager.Success;
        }
    }
}
