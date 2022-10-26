using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class carsContext : DbContext
    {
        public carsContext()
        {
        }

        public carsContext(DbContextOptions<carsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\cdigital\\Documents\\yoDb\\cars.db");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("cars");

                entity.HasIndex(e => e.Id, "IX_cars_Id")
                    .IsUnique();

                entity.Property(e => e.BoostType).HasColumnName("Boost type");

                entity.Property(e => e.EngineType).HasColumnName("Engine type");

                entity.Property(e => e.GearboxType).HasColumnName("Gearbox type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
