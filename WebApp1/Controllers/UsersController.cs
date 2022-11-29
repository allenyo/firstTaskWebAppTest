using api1Domain.Models;
using api1Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUser());
        }


        [HttpGet]
        public  async Task<IActionResult> GetUserByName(string name)
        {
            
            return Ok(await _userService.GetUser(name));
        }

        [HttpGet]
        public  async Task<IActionResult> GetUserById(int id)
        {

            return Ok(await _userService.GetUser(id));

        }

        [HttpPost]
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

        [HttpPut]
        public  async Task<IActionResult> DeleteUser(int userid)
        {
            var User = new UserID { Id = userid };


            return Ok(await _userService.DeleteUser(User));


        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User Data)
        {

            return Ok(await _userService.UpdateUser(Data));
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts(int userId)
        {
            return Ok(await _userService.GetAccounts(userId));
        }
    }
}
