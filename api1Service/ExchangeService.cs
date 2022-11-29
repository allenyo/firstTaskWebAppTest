using api1Domain.Models;

namespace api1Service
{
    public class ExchangeService : IExchangeService
    {
        private readonly RequestManager requestManager;
        private const string BaseUrl = "https://localhost:7234/api/exchange/";

        public ExchangeService(RequestManager requestManager)
        {
            this.requestManager = requestManager;
        }

        public async Task<object?> Exchange(ExchangeRequestModel requestModel)
        {
           await requestManager.Request($"{BaseUrl}exchange", HttpMethod.Post, requestModel);
            return requestManager?.Data;
        }
    }
}
