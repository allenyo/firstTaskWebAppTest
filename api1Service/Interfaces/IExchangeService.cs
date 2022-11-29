using api1Domain.Models;

namespace api1Service
{
    public interface IExchangeService
    {
        Task<object?> Exchange(ExchangeRequestModel requestModel);   
    }
}
