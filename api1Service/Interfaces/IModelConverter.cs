using api1Domain.Models;

namespace api1Domain.Interfaces
{
    public interface IModelConverter
    {
        BackUser? UserToBack(User user);
        User? BackToUser(BackUser user);
        BackUser? UserToBackUpdate(User user);


    }
}
