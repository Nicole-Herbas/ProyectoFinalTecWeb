using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajes;
        private readonly IConductorRepository _conductores;
        private readonly IPasajeroRepository _pasajeros;

        public ViajeService(IViajeRepository viajes, IConductorRepository conductor, IPasajeroRepository pasajero)
        {
            _viajes = viajes;
            _conductores = conductor;
            _pasajeros = pasajero;
        }
        public async Task<Guid> CreateAsync(CreateViajeDto dto)
        {
            var viaje = new Viaje
            {
                Id = Guid.NewGuid(),
                Origen = dto.Origen,
                Destino = dto.Destino,
                FechaFinalizacion = dto.FechaFinalizacion,
                FechaSolicitud = dto.FechaSolicitud,
                Precio = dto.Precio,
                Estado = dto.Estado,
                PasajeroId = dto.PasajeroId,
                ConductorId = dto.ConductorId
            };


            await _viajes.AddAsync(viaje);
            await _viajes.SaveChangesAsync();
            return viaje.Id;
        }
    }
}
