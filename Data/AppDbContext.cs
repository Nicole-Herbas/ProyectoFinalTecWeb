using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Viaje> Viajes => Set<Viaje>();

        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DriverVehiculo> DriverVehiculos => Set<DriverVehiculo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Origen).IsRequired().HasMaxLength(100);
                entity.Property(v => v.Destino).IsRequired().HasMaxLength(100);
                entity.Property(v => v.FechaSalida).IsRequired();
                entity.Property(v => v.Precio).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(v => v.Estado).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Marca).IsRequired().HasMaxLength(80);
                entity.Property(v => v.Modelo).IsRequired().HasMaxLength(80);
                entity.Property(v => v.Placa).IsRequired().HasMaxLength(15);
                entity.Property(v => v.Estado).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<DriverVehiculo>(entity =>
            {
                entity.HasKey(dv => dv.Id);

                entity.HasOne(dv => dv.Driver)
                      .WithMany(d => d.DriverVehiculos)
                      .HasForeignKey(dv => dv.DriverId);

                entity.HasOne(dv => dv.Vehiculo)
                      .WithMany(v => v.DriverVehiculos)
                      .HasForeignKey(dv => dv.VehiculoId);
            });
        }
    }
}
