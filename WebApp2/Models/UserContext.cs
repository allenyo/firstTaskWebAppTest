using Microsoft.EntityFrameworkCore;

namespace WebApp2.Models
{
    internal class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;

       

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

            Database.EnsureCreated();

        }
        

    }
}
