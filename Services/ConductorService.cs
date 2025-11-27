using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class ConductorService : IConductorService
    {
        private readonly IConductorRepository _conductores;
        private readonly IConfiguration _configuration;

        public ConductorService(IConductorRepository conductores, IConfiguration configuration)
        {
            _conductores = conductores;
            _configuration = configuration;
        }


        public async Task<Guid> CreateAsync(CreateConductorDto dto)
        {
            var entity = new Conductor { Nombre = dto.Nombre, Licencia = dto.Licencia, Telefono = dto.Telefono, Email = dto.Email };
            await _conductores.AddAsync(entity);
            await _conductores.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteConductor(Guid id)
        {
            Conductor? conductor = (await GetAll()).FirstOrDefault(h => h.Id == id);
            if (conductor == null) return;
            await _conductores.Delete(conductor);
        }

        public async Task<IEnumerable<Conductor>> GetAll()
        {
            return await _conductores.GetAll();
        }

        public async Task<Conductor> GetOne(Guid id)
        {
            return await _conductores.GetOne(id);
        }

        public async Task<string> RegisterAsync(RegisterConductorDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var conductor = new Conductor
            {
                Email = dto.Email,
                Nombre = dto.Nombre
            };
            await _conductores.AddAsync(conductor);
            return conductor.Id.ToString();
        }

        public async Task<Conductor> UpdateConductor(UpdateConductorDto dto, Guid id)
        {
            Conductor? conductor = await GetOne(id);
            if (conductor == null) throw new Exception("Hospital doesnt exist.");

            conductor.Nombre = dto.Nombre;
            conductor.Licencia = dto.Licencia;
            conductor.Telefono = dto.Telefono;
            conductor.Email = dto.Email;

            await _conductores.Update(conductor);
            return conductor;
        }
    }
}
