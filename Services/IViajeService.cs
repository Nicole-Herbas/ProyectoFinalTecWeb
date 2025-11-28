using ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IViajeService
    {
        Task<Guid> CreateAsync(CreateViajeDto dto);

        //Task<ViajePasajeroDto?> GetPasajeroAsync(int id);
    }
}
