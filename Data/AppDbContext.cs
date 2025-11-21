using Microsoft.EntityFrameworkCore;
using Security.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaxiApi.Models;

namespace TaxiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Por ahora, SOLO Vehículos
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Placa única
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.Plate)
                .IsUnique();
        }
    }
}
