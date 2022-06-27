using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        public async Task<ActionResult<User>> UpdateUser(JObject data)
        {

            var user = data?["user"]?.ToObject<User>();
            var fName = data?["fname"]?.ToString();
            var lName = data?["lname"]?.ToString();
            var email = data?["email"]?.ToString();
            var phone = data?["phone"]?.ToString();
            var byear = data["byear"].ToObject<int>();
            var bmonth = data["bmonth"].ToObject<int>();
            var bday = data["bday"].ToObject<int>();

            if (user == null)
                return BadRequest();

            try
            {
               
            if (fName != null)
                user.FirstName = fName;
          await Db.SaveChangesAsync();    
            
            if (lName != null)
                user.LastName = lName;
          await Db.SaveChangesAsync();

            if (email != null)
                user.Email = email;
          await Db.SaveChangesAsync();    
            
            if (phone != null)
                user.Phone = phone;
          await Db.SaveChangesAsync();

            if (byear != 0)
                user.BirthYear = byear;
          await Db.SaveChangesAsync();

            if (bmonth != 0)
                user.BirthMonth = bmonth;
          await Db.SaveChangesAsync();

            if (bday != 0)
                user.BirthDay = bday;
          await Db.SaveChangesAsync();

                return user;
            }

            catch(WebException ex)
            {
                return BadRequest(ex.Message);

            }
         

        }
    

    }
}
