using Domain.Models;

namespace Service
{
    public interface IExchangeService
    {
        string Exchange(ExchangeRequestModel requestModel);
    }
}
