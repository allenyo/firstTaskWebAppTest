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

  
        
        async Task GetResponse(string url)
        {
            _response = await _httpClient.GetAsync(url);

            Data = await _response.Content.ReadAsStringAsync();

            Status = _response.StatusCode.ToString();

            Success = _response.IsSuccessStatusCode;


        }

       
        public async Task GetUser()
        {
            await GetResponse("https://localhost:7234/api/users/getusers");
        }

        public async Task GetUser(string name)
        {
            await GetResponse($"https://localhost:7234/api/users/getusers/{name}");
        }


        public async Task GetUser(int id)
        {
            await GetResponse($"https://localhost:7234/api/users/getusers/id{id}");
        }

        public async Task CreateUser(User user)
        {
            var converter = new ModelConverter();
            var User = converter.UserToBack(user);

               _response = await _httpClient.PostAsJsonAsync("https://localhost:7234/api/users/createuser/", User);              

            
        }

        public async Task DeleteUser(User user)
        {
            _response = await _httpClient.PutAsJsonAsync("https://localhost:7234/api/users/deleteuser/", user);
        }


        public async Task UpdateUser(User user)
        {
            var converter = new ModelConverter();
            var data = converter.UserToBackUpdate(user);

             _response = await _httpClient.PostAsJsonAsync("https://localhost:7234/api/users/updateuser/", data);

          

        }
    }
}
