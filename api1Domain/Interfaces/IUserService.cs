using api1Domain.Models;

namespace api1Domain.Interfaces
{
    public interface IUserService
    {
        Task GetUser();
        Task GetUser(string name);
        Task GetUser(int name);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);

        public string Status { get; set; } 

        public string? Data { get; set; } 

        public bool Success { get; set; }

    }
}
