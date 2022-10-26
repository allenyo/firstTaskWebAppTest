using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public sealed class RepositoryDBContext : DbContext 
    {
        public DbSet<User> Users { get; set; } = null!;
    

        public RepositoryDBContext (DbContextOptions<RepositoryDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
