using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly AppDbContext _context;

    public VehicleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles
            .Include(v => v.Model)
            .Include(v => v.Driver)
            .ToListAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _context.Vehicles
            .Include(v => v.Model)
            .Include(v => v.Driver)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Vehicle vehicle)
    {
        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
    }
}