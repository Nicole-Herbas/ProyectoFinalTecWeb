using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IPasajeroRepository
    {
        Task<Pasajero?> GetByEmailAddress(string email);

        Task<Pasajero?> GetViajesAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();


        //CRUD
        Task AddAsync(Pasajero pasajero);
        Task<IEnumerable<Pasajero>> GetAll();
        Task<Pasajero> GetOne(Guid id);
        Task Update(Pasajero pasajero);
        Task Delete(Pasajero pasajero);
    }
}
