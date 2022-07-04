using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsers(string name);
        Task<User> GetUsers(int id);
        Task CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(User user);

    }
}
