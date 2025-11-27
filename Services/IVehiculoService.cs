using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IVehiculoService
    {
        Task<Guid> CreateAsync(CreateVehiculoDto dto);
        Task<Vehiculo> GetByIdAsync(Guid id);
        Task<Vehiculo> UpdateAsync(UpdateVehicleDto dto, Guid id);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Vehiculo>> GetAll();

        /*
         Task<Guid> CreateAsync(CreateConductorDto dto);
        Task<IEnumerable<Conductor>> GetAll();
        Task<Conductor> GetOne(Guid id);
        Task<Conductor> UpdateConductor(UpdateConductorDto dto, Guid id);
        Task DeleteConductor(Guid id);
         */
    }
}