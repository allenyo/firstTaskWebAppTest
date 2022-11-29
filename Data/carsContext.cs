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
