using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp1.Models;

namespace WebApp1
{
    public class WebCall
    {
     
       private static WebCall? _webcall;

        private WebCall()
        {

        }
        public static WebCall Instance()
        {
            if (_webcall == null)
                _webcall = new WebCall();

            return _webcall;

        }

       public HttpClient client = new();

       public HttpResponseMessage? response = new();

       public string Status { get; set; } = string.Empty;

       public string? Data { get; set; } = null;

       public bool Success { get; set; }

        public async Task GetResponse(string url)
        {
            response = await client.GetAsync(url);

            Data = await response.Content.ReadAsStringAsync();

            Status = response.StatusCode.ToString();

            Success = response.IsSuccessStatusCode;

         
        }

       public static async Task<string> GetUser()
        {
            if (_webcall != null)
            {
                await _webcall.GetResponse("https://localhost:7234/api/users/getusers");

                if (!_webcall.Success || _webcall.Data == null)
                    return _webcall.Status.ToString();

                return _webcall.Data.ToString();


            }
            return string.Empty;
        }

       public static async Task<string> GetUser(string name)
        {
            if (_webcall != null)
            {
                await _webcall.GetResponse($"https://localhost:7234/api/users/getusers/{name}");

                if (!_webcall.Success || _webcall.Data == null)
                    return _webcall.Status.ToString();

                return _webcall.Data.ToString();

            }
            return string.Empty;

        }

       public static async Task<string> GetUser(int id)
        {
            if (_webcall != null)
            {
                await _webcall.GetResponse($"https://localhost:7234/api/users/id{id}");

                if (!_webcall.Success || _webcall.Data == null)
                    return _webcall.Status.ToString();

                return _webcall.Data.ToString();


            }
            return string.Empty;
        }  
          
       public static async Task<string> CreateUser(User user)
        {
            
            var converter = new ModelConverter();
            var User = converter.UserToOut(user);

            if (_webcall != null && User !=null)
            {

                _webcall.response = await _webcall.client.PostAsJsonAsync("https://localhost:7234/api/users/createuser/", User);

           
                return _webcall.response.ToString();


            }
            return string.Empty;
        }

       public static async Task<string> DeleteUser(User user)
        {

            var converter = new ModelConverter();
            var User = converter.UserToOut(user);
          
            if (_webcall != null)
            {
                _webcall.response = await _webcall.client.PutAsJsonAsync("https://localhost:7234/api/users/deleteuser/", User);
             
                return _webcall.response.ToString();


            }
            return string.Empty;
        }  
        
       public static async Task<string> UpdateUser(JObject data )
        {  
            if (data != null)
            {       
                if (_webcall != null)
                {
                    _webcall.response = await _webcall.client.PostAsJsonAsync("https://localhost:7234/api/users/updateuser/", data);

                    return _webcall.response.ToString();


                }
                return string.Empty;

            }
                    
            return string.Empty;
        }

    }
}
