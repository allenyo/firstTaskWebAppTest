using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApp2.Controllers
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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() 
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        [HttpGet("getusers/{name}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(string name) 
        {
            var users = await _userService.GetUsers(name);    
            if (!users.Any())
                return NotFound();

            return Ok(users);
        }

        [HttpGet("getusers/id{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(int id) 
        {
            var user = await _userService.GetUsers(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        
        [HttpPost("createuser")]
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

        [HttpPut("deleteuser")]
        public async Task<IActionResult> DeleteUser (User user)
        {
            var User = _userService.GetUsers(user.Id).Result;

            if (User == null)
                return NotFound();

                await _userService.DeleteUser(user);
               return Accepted();
            
        }


        [HttpPost("updateuser")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            var check = await _userService.UpdateUser(user);

            if (check == null)
                return NotFound();

            return Ok(check);
        }
          
     

    }
    

}

