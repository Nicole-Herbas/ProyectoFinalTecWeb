using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AppDbContext _ctx;

        public VehiculoRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddAsync(Vehiculo vehiculo)
            => await _ctx.Vehiculos.AddAsync(vehiculo);

        public Task<Vehiculo?> GetVehiculoAsync(Guid id)
            => _ctx.Vehiculos.FirstOrDefaultAsync(v => v.Id == id);

        public Task<bool> ExistsPlacaAsync(string placa)
            => _ctx.Vehiculos.AnyAsync(v => v.Placa == placa);

        public Task<int> SaveChangesAsync()
            => _ctx.SaveChangesAsync();
    }
}