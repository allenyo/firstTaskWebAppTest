using Domain.Models;

namespace Service
{
    public interface IExchangeService
    {
        Task<string> Exchange(ExchangeRequestModel requestModel);
    }
}
