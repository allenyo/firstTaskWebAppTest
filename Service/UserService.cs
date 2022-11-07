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
            var users = _dbContext.Users.FromSqlInterpolated(@$"SELECT * FROM Users WHERE FirstName LIKE {name} OR LastName LIKE {name}");

            return await users.ToListAsync();
        }


        public async Task<User?> GetUsers(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);

            return user;
        }


        public async Task<User?> CreateUser(User user)
        {
            var Users = _dbContext.Users.FromSqlInterpolated(@$"SELECT * FROM Users WHERE FirstName LIKE {user.FirstName} AND
                           LastName LIKE {user.LastName} AND Email LIKE {user.Email} AND Phone LIKE {user.Phone} AND BirthDay LIKE {user.BirthDay} AND
                           BirthMonth LIKE {user.BirthMonth} AND BirthYear LIKE {user.BirthYear}

            ").ToListAsync().Result;

            if (Users.Count<1)
                {
                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();
                    return user;
                }
                return null;
  
        }

        public async Task DeleteUser(User User)
        {
            var user = await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(i => i.Id == User.Id);    
            if (user != null)
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            
        }


        public async Task<User?> UpdateUser(User user)
        {
            var updateUser = _dbContext.Users.FirstOrDefault(i => i.Id == user.Id);

                if(updateUser != null)
            {
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

                }

                             
                return updateUser;
        }
      
    }
}
