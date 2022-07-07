using api1Domain.Interfaces;
using api1Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("getusers")]
        public async Task<string?> GetUser()
        {    
            await _userService.GetUser();
            return _userService.Data;
        }


        [HttpGet("getusers/{name}")]
        public  async Task<string?> GetUser(string name)
        {
            await _userService.GetUser(name);
            return _userService.Data;
        }

        [HttpGet("getusers/id{id}")]
        public  async Task<string?> GetUser(int id)
        {
            await _userService.GetUser(id);
            return _userService.Data;

        }

        [HttpPost("createuser")]
        public  async Task<ActionResult<string>> CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (user.FullName == string.Empty || user.BirthDay == string.Empty
                || user.Email == string.Empty || user.Phone == string.Empty)
            {
                return BadRequest();
            }

            await _userService.CreateUser(user);
            return _userService.Status;
        }

        [HttpPut("deleteuser")]
        public  async Task<string> DeleteUser(int userid)
        {
            var User = new UserID { Id = userid };

            await _userService.DeleteUser(User);
            return _userService.Status;


        }

        [HttpPost("updateuser")]
        public async Task<string?> UpdateUser(User Data)
        {
           await _userService.UpdateUser(Data);
            return _userService.Status;
        }

    }
}
