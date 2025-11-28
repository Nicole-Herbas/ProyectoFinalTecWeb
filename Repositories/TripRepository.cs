using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories;

public class TripRepository : ITripRepository
{
    private readonly AppDbContext _context;

    public TripRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
    {
        return await _context.Trips
            .Include(t => t.Passenger)
            .Include(t => t.Driver)
            .ToListAsync();
    }

    public async Task<Trip?> GetByIdAsync(Guid id)
    {
        return await _context.Trips
            .Include(t => t.Passenger)
            .Include(t => t.Driver)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Trip trip)
    {
        await _context.Trips.AddAsync(trip);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Trip trip)
    {
        _context.Trips.Update(trip);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Trip trip)
    {
        _context.Trips.Remove(trip);
        await _context.SaveChangesAsync();
    }
}