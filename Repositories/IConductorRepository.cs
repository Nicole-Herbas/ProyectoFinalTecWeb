using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IConductorRepository
    {
        Task<Conductor?> GetByEmailAddress(string email);
        
        Task<Conductor?> GetViajesAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();


        //CRUD
        Task AddAsync(Conductor conductor);
        Task<IEnumerable<Conductor>> GetAll();
        Task<Conductor?> GetOne(Guid id);
        Task Update (Conductor conductor);
        Task Delete(Conductor conductor);

    }
}
