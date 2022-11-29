using api1Domain.Models;

namespace api1Service
{
    public interface IModelConverter
    {
        BackUser? UserToBack(User user);
        User? BackToUser(BackUser user);
        BackUser? UserToBackUpdate(User user);


    }
}
