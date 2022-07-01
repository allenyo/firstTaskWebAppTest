using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UserContext Db { get; set; }

        public UsersController(UserContext context)
        {
            Db = context;
        }

        [HttpGet("getusers")]
        public async Task<User[]> GetUsers()
        {
            return await Db.Users.ToArrayAsync();
        }

        [HttpGet("getusers/{name}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(string name)
        {
            var users = Db.Users.Where(i => i.FirstName.ToLower() == name.ToLower() || i.LastName.ToLower() == name.ToLower());
            if (users == null)
                return BadRequest();

            return await users.ToListAsync();
        }

        [HttpGet("getusers/id{id}")]
        public async Task<object> GetUsers(int id)
        {
            User? user = await Db.Users.FirstOrDefaultAsync(i => i.Id == id);

            if (user == null)
                return BadRequest();

            return user;
        }

        
        [HttpPost("createuser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {

            if (user == null)
                return BadRequest();

            try
            {
                Db.Users.Add(user);
                await Db.SaveChangesAsync();
                return Ok(user);

            }
            catch (WebException ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("deleteuser")]
        public async Task<ActionResult<User>> DeleteUser(User user)
        {


            if (user == null)
                return BadRequest();

            try
            {
                Db.Users.Remove(user);
                await Db.SaveChangesAsync();
                return Ok(user);

            }
            catch (WebException ex)
            {
                return BadRequest(ex.Message);

            }

        }


        [HttpPost("updateuser")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {

            var updateUser = Db.Users.FirstOrDefault(i => i.Id == user.Id);

            if (updateUser == null) 
                return BadRequest();

                try
                {
                if (!string.IsNullOrEmpty(user.FirstName))
                    updateUser.FirstName = user.FirstName;
                    await Db.SaveChangesAsync();
                
                if (!string.IsNullOrEmpty(user.LastName))
                    user.LastName = user.LastName;
                await Db.SaveChangesAsync();

                if (!string.IsNullOrEmpty(user.Email))
                    updateUser.Email = user.Email;
                await Db.SaveChangesAsync();

                if(!string.IsNullOrEmpty(user.Phone))
                    updateUser.Phone = user.Phone;
                await Db.SaveChangesAsync();

                if (!string.IsNullOrEmpty(user.BirthDay))
                    updateUser.BirthDay = user.BirthDay;
                await Db.SaveChangesAsync();

                if (!string.IsNullOrEmpty(user.BirthMonth))    
                    updateUser.BirthMonth = user.BirthMonth;
                await Db.SaveChangesAsync();

                if (!string.IsNullOrEmpty(user.BirthYear))
                    updateUser.BirthYear=user.BirthYear;
                await Db.SaveChangesAsync();

                if (user.Time != DateTime.MinValue)
                    updateUser.Time = user.Time;
                await Db.SaveChangesAsync();

                return updateUser;
               
                   
                }

                catch (WebException ex)
                {
                    return BadRequest(ex.Message);

                }

        }
          

    }
    

}

