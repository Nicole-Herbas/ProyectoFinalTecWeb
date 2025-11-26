using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IVehiculoRepository
    {
        Task AddAsync(Vehiculo vehiculo);
        Task<Vehiculo?> GetVehiculoAsync(Guid id);
        Task<bool> ExistsPlacaAsync(string placa);
        Task<int> SaveChangesAsync();
    }
}