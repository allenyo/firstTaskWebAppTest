using api1Domain.Models;

namespace api1Domain.Interfaces
{
    public interface IPayService
    {
        Task<bool> PayToAccount(PayToAccountModel payTo);
    }
}
