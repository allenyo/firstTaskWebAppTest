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
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasIndex(e => e.Account, "account")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.Type).HasColumnName("Type");

                entity.Property(e => e.Currency).HasColumnName("Currency");

                entity.Property(e => e.Balance).HasColumnName("Balance").HasColumnType("decimal");

                entity.HasKey(e => e.Account);


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
