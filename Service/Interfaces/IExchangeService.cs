using Domain.Models;

namespace Domain.Interfaces
{
    public interface IExchangeService
    {
        Task<string> Exchange(ExchangeRequestModel requestModel);
    }
}
