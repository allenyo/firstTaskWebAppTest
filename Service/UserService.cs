using Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Service
{
    public sealed class UserService : IUserService
    {

        private readonly RepositoryDBContext _dbContext;

        public UserService(RepositoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers(string name)
        {
           
            
            name = name[1..].ToLowerInvariant().Insert(0, char.ToUpper(name[0]).ToString());
            var users = _dbContext.Users.FromSqlInterpolated(@$"SELECT * FROM Users WHERE FirstName LIKE {name} OR 
                FirstName LIKE {name.ToLowerInvariant()} OR Firstname LIKE {name.ToUpperInvariant()} ");

            return await users.ToListAsync();
        }


        public async Task<User?> GetUsers(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);

            return user;
        }


        public async Task CreateUser(User user)
        {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
       
        }

        public async Task DeleteUser(User User)
        {
            var user = _dbContext.Users.FirstOrDefault(i => i.Id == User.Id);    
            if (user != null)
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
            
        }


        public async Task<User> UpdateUser(User user)
        {
            var updateUser = _dbContext.Users.First(i => i.Id == user.Id);

                if (!string.IsNullOrEmpty(user.FirstName))
            {
                updateUser.FirstName = user.FirstName;
                await _dbContext.SaveChangesAsync();

            }
               
                if (!string.IsNullOrEmpty(user.LastName))
            {
                updateUser.LastName = user.LastName;
                await _dbContext.SaveChangesAsync();
            }
                    

                if (!string.IsNullOrEmpty(user.Email))
            {
                updateUser.Email = user.Email;
                await _dbContext.SaveChangesAsync();
            }
                  

                if (!string.IsNullOrEmpty(user.Phone))
            {
                updateUser.Phone = user.Phone;
                await _dbContext.SaveChangesAsync();
            }
            

                if (!string.IsNullOrEmpty(user.BirthDay))
            {
                updateUser.BirthDay = user.BirthDay;
                await _dbContext.SaveChangesAsync();
            }
                

                if (!string.IsNullOrEmpty(user.BirthMonth))
            {
                updateUser.BirthMonth = user.BirthMonth;
                await _dbContext.SaveChangesAsync();
            }
                 

                if (!string.IsNullOrEmpty(user.BirthYear))
            {
                updateUser.BirthYear = user.BirthYear;
                await _dbContext.SaveChangesAsync();
            }
              
                return updateUser;
        }

 
    }
}
