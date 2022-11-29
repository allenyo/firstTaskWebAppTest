using api1Domain.Models;

namespace api1Service
{
    public interface IPayService
    {
        Task<bool> PayToAccount(PayToAccountModel payTo);
    }
}
