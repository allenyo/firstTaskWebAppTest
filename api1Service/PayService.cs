using api1Domain.Interfaces;

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
    }
}
