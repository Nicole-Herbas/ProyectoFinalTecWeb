using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public interface IVehiculoService
    {
        Task<Guid> CreateAsync(CreateVehicleDto dto);
        Task<Vehiculo?> GetByIdAsync(Guid id);
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<bool> UpdateAsync(Guid id, UpdateVehicleDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
