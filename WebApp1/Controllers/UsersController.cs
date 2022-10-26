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
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetUser());
        }


        [HttpGet("getbyname/{name}")]
        public  async Task<IActionResult> GetUser(string name)
        {
            
            return Ok(await _userService.GetUser(name));
        }

        [HttpGet("getbyid/{id}")]
        public  async Task<IActionResult> GetUser(int id)
        {

            return Ok(await _userService.GetUser(id));

        }

        [HttpPost("createuser")]
        public  async Task<IActionResult> CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (user.FullName == string.Empty || user.BirthDay == string.Empty
                || user.Email == string.Empty || user.Phone == string.Empty)
            {
                return BadRequest();
            }


            return Ok( await _userService.CreateUser(user));
        }

        [HttpPut("deleteuser")]
        public  async Task<IActionResult> DeleteUser(int userid)
        {
            var User = new UserID { Id = userid };


            return Ok(await _userService.DeleteUser(User));


        }

        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(User Data)
        {

            return Ok(await _userService.UpdateUser(Data));
        }

    }
}
