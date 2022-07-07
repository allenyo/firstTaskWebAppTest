using api1Domain.Interfaces;
using api1Domain.Models;
using System.Net.Http.Json;

namespace api1Service
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient = new();
        private  HttpResponseMessage _response = new();

        public string Status { get; set; } = string.Empty;

        public string? Data { get; set; }

        public bool Success { get; set; }

  
        async Task Request(string url, HttpMethod method, object? data = null)
        {
            if (data == null && method == HttpMethod.Get)
            {
                _response = await _httpClient.GetAsync(url);
                Data = await _response.Content.ReadAsStringAsync();
            }

            if (data !=null && method == HttpMethod.Post)
                _response = await _httpClient.PostAsJsonAsync(url, data);

            if (data!=null && method == HttpMethod.Put)
                _response = await _httpClient.PutAsJsonAsync(url, data);

            Status = _response.StatusCode.ToString();

            Success = _response.IsSuccessStatusCode;



        }

       
        public async Task GetUser()
        {
            await Request("https://localhost:7234/api/users/getusers", HttpMethod.Get);
        }

        public async Task GetUser(string name)
        {
            await Request($"https://localhost:7234/api/users/getusers/{name}", HttpMethod.Get);
        }


        public async Task GetUser(int id)
        {
            await Request($"https://localhost:7234/api/users/getusers/id{id}", HttpMethod.Get);
        }

        public async Task CreateUser(User user)
        {         

                var converter = new ModelConverter();
                var User = converter.UserToBack(user);
                await Request("https://localhost:7234/api/users/createuser/", HttpMethod.Post, User);

         
        }

        public async Task DeleteUser(UserID user)
        {
            await Request("https://localhost:7234/api/users/deleteuser/", HttpMethod.Put, user);

        }


        public async Task UpdateUser(User user)
        {
                var converter = new ModelConverter();
                var User = converter.UserToBackUpdate(user);
                await Request("https://localhost:7234/api/users/updateuser/", HttpMethod.Post, User);
                        
        }

     
    }
}
