using api1Domain.Interfaces;
using api1Domain.Models;

namespace api1Service
{
    public class UserService : IUserService
    {

        private readonly RequestManager _requestManager;
        private readonly string baseurl= "https://localhost:7234/api/users/";

        public UserService(RequestManager requestManager)
        {
            _requestManager = requestManager;

        }

        public async Task<object?> GetUser()
        {
            await _requestManager.Request($"{baseurl}getusers", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<object?> GetUser(string name)
        {
            await _requestManager.Request($"{baseurl}getbyname/{name}", HttpMethod.Get);
            return _requestManager.Data;
        }


        public async Task<object?> GetUser(int id)
        {
            await _requestManager.Request($"{baseurl}getbyid/{id}", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<bool> CreateUser(User user)
        {         

                var converter = new ModelConverter();
                var User = converter.UserToBack(user);
                await _requestManager.Request($"{baseurl}createuser", HttpMethod.Post, User);
            return _requestManager.Success;


        }

        public async Task<bool> DeleteUser(UserID user)
        {
            await _requestManager.Request($"{baseurl}deleteuser", HttpMethod.Put, user);
            return _requestManager.Success;

        }


        public async Task<bool> UpdateUser(User user)
        {
             var converter = new ModelConverter();
             var User = converter.UserToBackUpdate(user);
             await _requestManager.Request($"{baseurl}updateuser", HttpMethod.Post, User);
             return _requestManager.Success;

        }

     
    }
}
