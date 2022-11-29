using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UsersController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() 
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByName(string name) 
        {
            var users = await _userService.GetUsers(name);    
            if (!users.Any())
                return NotFound();

            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById(int id) 
        {
            var user = await _userService.GetUsers(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user) 
        {
            if (user.Id != 0)
            {
                var User = _userService.GetUsers(user.Id).Result;

                if (User == null)
                {
                    await _userService.CreateUser(user);
                    return CreatedAtAction(nameof(CreateUser), user);
                } else { return BadRequest(); }

            }
            else
            {
                 var res = await _userService.CreateUser(user);

                if (res == null)
                    return BadRequest();

                return CreatedAtAction(nameof(CreateUser), user);
            }            

        }

        [HttpPut]
        public async Task<IActionResult> DeleteUser (User user)
        {     
                await _userService.DeleteUser(user);
               return Accepted();
            
        }


        [HttpPost]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            var check = await _userService.UpdateUser(user);

            if (check == null)
                return NotFound();

            return Ok(check);
        }


        [HttpGet]
        public async Task<IActionResult> GetAccounts(int userId)
        {
            return Ok(await _accountService.GetAccounts(userId));
        }
    }
    
}

