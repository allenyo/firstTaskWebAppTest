using Microsoft.AspNetCore.Mvc;
using WebApp1.Converters;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        readonly HttpClient Client = new();

        public  HttpResponseMessage? response = new();

        public string Status { get; set; } = string.Empty;

        public string? Data { get; set; } = null;

        public bool Success { get; set; }

        async Task GetResponse(string url)
        {
            response = await Client.GetAsync(url);

            Data = await response.Content.ReadAsStringAsync();

            Status = response.StatusCode.ToString();

            Success = response.IsSuccessStatusCode;


        }


        [HttpGet("getusers")]
        public  async Task<string> GetUser()
        {
            
                await  GetResponse("https://localhost:7234/api/users/getusers");

                if (!Success || Data == null)
                    return Status.ToString();

                return Data.ToString();


        
        }

        [HttpGet("getusers/{name}")]
        public  async Task<string> GetUser(string name)
        {
                   
                await GetResponse($"https://localhost:7234/api/users/getusers/{name}");

                if (!Success || Data == null)
                    return Status.ToString();

                return Data.ToString();       

        }

        [HttpGet("getusers/id{id}")]
        public  async Task<string> GetUser(int id)
        {
           
                await GetResponse($"https://localhost:7234/api/users/getusers/id{id}");

                if (!Success || Data == null)
                    return Status.ToString();

                return Data.ToString();

        }

        [HttpPost("createuser")]
        public  async Task<string> CreateUser(User user)
        {

            var converter = new ModelConverter();
            var User = converter.UserToOut(user);

            if (User != null)
            {

                response = await Client.PostAsJsonAsync("https://localhost:7234/api/users/createuser/", User);


                return response.ToString();


            }
            return string.Empty;
        }

        [HttpPut("deleteuser")]
        public  async Task<string> DeleteUser(User user)
        {

            var converter = new ModelConverter();
            var User = converter.UserToOut(user);
         
                response = await Client.PutAsJsonAsync("https://localhost:7234/api/users/deleteuser/", User);

                return response.ToString();


        }

        [HttpPost("updateuser")]
        public  async Task<string> UpdateUser(User Data)
        {
            var converter = new ModelConverter();
            var data = converter.UserToOut(Data);

            if (data != null)
            {
               


                  response = await Client.PostAsJsonAsync("https://localhost:7234/api/users/updateuser/", data);

                    return response.ToString();
                
            
            }

            return string.Empty;
        }

    }
}
