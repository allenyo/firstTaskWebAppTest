using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class RepositoryDBContext : DbContext 
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Accounts> Accounts { get; set; } = null!;
    

        public RepositoryDBContext (DbContextOptions<RepositoryDBContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
