using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IVehiculoRepository
    {
        Task AddAsync(Vehiculo vehiculo);
        Task<Vehiculo?> GetByIdAsync(Guid id);
        Task<bool> PlacaExistsAsync(string placa);
        Task<int> SaveChangesAsync();
        Task<IEnumerable<Vehiculo>> GetAll();
        Task Update(Vehiculo vehiculo);
        Task Delete(Vehiculo vehiculo);
    }
}