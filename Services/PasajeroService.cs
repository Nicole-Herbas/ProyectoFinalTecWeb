using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class PasajeroService : IPasajeroService
    {
        private readonly IPasajeroRepository _pasajeros;
        private readonly IConfiguration _configuration;
        public PasajeroService(IPasajeroRepository pasajeros, IConfiguration configuration)
        {
            _pasajeros = pasajeros;
            _configuration = configuration;
        }
        public async Task<Guid> CreateAsync(CreatePasajeroDto dto)
        {
            var entity = new Pasajero { Nombre = dto.Nombre, Telefono = dto.Telefono, Email = dto.Email };
            await _pasajeros.AddAsync(entity);
            await _pasajeros.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeletePasajero(Guid id)
        {
            Pasajero? pasajero = (await GetAll()).FirstOrDefault(h => h.Id == id);
            if (pasajero == null) return;
            await _pasajeros.Delete(pasajero);
        }

        public async Task<IEnumerable<Pasajero>> GetAll()
        {
            return await _pasajeros.GetAll();
        }

        public async Task<Pasajero> GetOne(Guid id)
        {
            return await _pasajeros.GetOne(id);
        }

        public async Task<string> RegisterAsync(RegisterPasajeroDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var pasajero = new Pasajero
            {
                Email = dto.Email,
                Nombre = dto.Nombre
            };
            await _pasajeros.AddAsync(pasajero);
            return pasajero.Id.ToString();
        }

        public async Task<Pasajero> UpdatePasajero(UpdatePasajeroDto dto, Guid id)
        {
            Pasajero? pasajero = await GetOne(id);
            if (pasajero == null) throw new Exception("Pasajero doesnt exist.");

            pasajero.Nombre = dto.Nombre;
            pasajero.Telefono = dto.Telefono;
            pasajero.Email = dto.Email;

            await _pasajeros.Update(pasajero);
            return pasajero;
        }
    }
}
