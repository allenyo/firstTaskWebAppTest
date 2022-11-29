using Domain.Models;

namespace Service
{
    public interface IPayService
    {
        Task<bool> PayToAccount(PayToAccountModel payTo);
    }
}
