using api1Domain.Models;

namespace api1Domain.Interfaces
{
    public interface IExchangeService
    {
        Task<object?> Exchange(ExchangeRequestModel requestModel);   
    }
}
