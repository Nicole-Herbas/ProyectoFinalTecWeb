using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IViajeRepository
    {
        Task AddAsync(Viaje viaje);
        Task<Viaje?> GetViajeAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
