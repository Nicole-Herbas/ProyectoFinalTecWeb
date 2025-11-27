using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajes;

        public ViajeService(IViajeRepository viajes)
        {
            _viajes = viajes;
        }
        public async Task<int> CreateAsync(CreateViajeDto dto)
        {
            var endUtc = dto.FechaFinalizacion.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dto.FechaFinalizacion, DateTimeKind.Utc)
                : dto.FechaFinalizacion.ToUniversalTime();

           

            var viaje = new Viaje
            {
                Id = Guid.NewGuid(),
                Origen = dto.Origen,
                Destino = dto.Destino,
                FechaFinalizacion = dto.FechaFinalizacion,
                FechaSolicitud = dto.FechaSolicitud,
                Precio = dto.Precio,
                Estado = dto.Estado
            };

            await _viajes.AddAsync(viaje);
            return await _viajes.SaveChangesAsync();
        }
    }
}
