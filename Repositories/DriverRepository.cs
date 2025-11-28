using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories;

public class DriverRepository : IDriverRepository
{
    private readonly AppDbContext _context;

    public DriverRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers.ToListAsync();
    }

    public async Task<Driver?> GetByIdAsync(Guid id)
    {
        return await _context.Drivers.FindAsync(id);
    }

    public async Task<Driver?> GetByEmailAsync(string email)
    {
        return await _context.Drivers.FirstOrDefaultAsync(d => d.Email == email);
    }

    public async Task AddAsync(Driver driver)
    {
        await _context.Drivers.AddAsync(driver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Driver driver)
    {
        _context.Drivers.Update(driver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Driver driver)
    {
        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
    }
}