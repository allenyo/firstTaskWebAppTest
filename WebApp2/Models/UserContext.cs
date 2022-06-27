using Microsoft.EntityFrameworkCore;

namespace WebApp2.Models
{
    public class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, FirstName = "Alen", LastName = "Sahakyan", Email = "superalstudio@mail.ru", Phone = "+37498506789", BirthYear = 2000, BirthMonth = 5, BirthDay = 18, Time = DateTime.UtcNow },
                    new User { Id = 2, FirstName = "Hrayr", LastName = "Hakobyan", Email = "hak@mail.ru", Phone = "+37493405728", BirthYear = 1980, BirthMonth = 8, BirthDay = 4, Time = DateTime.UtcNow },
                    new User { Id = 3, FirstName = "Lilit", LastName = "Grigoryan", Email = "Lilili@mail.ru", Phone = "+37497534891", BirthYear = 1999, BirthMonth = 11, BirthDay = 9, Time = DateTime.UtcNow },
                    new User { Id = 4, FirstName = "Karen", LastName = "Barkhudaryan", Email = "abushka@mail.ru", Phone = "+7895471236", BirthYear = 2005, BirthMonth = 5, BirthDay = 18, Time = DateTime.UtcNow }
            );
        }*/
    }
}
