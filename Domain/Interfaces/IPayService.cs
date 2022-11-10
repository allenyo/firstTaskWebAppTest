using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPayService
    {
        Task<bool> PayToAccount(PayToAccountModel payTo);
    }
}
