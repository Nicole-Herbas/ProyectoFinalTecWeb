using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public class PasajeroRepository : IPasajeroRepository
    {
        private readonly AppDbContext _ctx;
        public PasajeroRepository(AppDbContext ctx) { _ctx = ctx; }
        public async Task AddAsync(Pasajero pasajero)
        {
            _ctx.Pasajeros.Add(pasajero);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(Pasajero pasajero)
        {
            _ctx.Pasajeros.Remove(pasajero);
            await _ctx.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Guid id) =>
            _ctx.Pasajeros.AnyAsync(s => s.Id == id);

        public async Task<IEnumerable<Pasajero>> GetAll()
        {
            return await _ctx.Pasajeros.ToListAsync();
        }

        public Task<Pasajero?> GetByEmailAddress(string email) =>
            _ctx.Pasajeros.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<Pasajero> GetOne(Guid id)
        {
            return await _ctx.Pasajeros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Pasajero?> GetViajesAsync(Guid id) =>
            _ctx.Pasajeros
                .Include(s => s.Viajes)
                .FirstOrDefaultAsync(s => s.Id == id);

        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();

        public async Task Update(Pasajero pasajero)
        {
            _ctx.Pasajeros.Update(pasajero);
            await _ctx.SaveChangesAsync();
        }
    }
}
