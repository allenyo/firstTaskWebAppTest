using Domain.Models;

namespace Service
{
    public interface IUserService
    {

        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsers(string name);
        Task<User?> GetUsers(int id);
        Task<User?> CreateUser(User user);
        Task<User?> UpdateUser(User user);
        Task DeleteUser(User user);
   
    }
}
