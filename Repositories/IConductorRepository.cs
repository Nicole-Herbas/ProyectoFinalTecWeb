using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IConductorRepository
    {
        Task<User?> GetByEmailAddress(string email);
        Task<User?> GetByRefreshToken(string refreshToken);
        Task AddAsync(Conductor conductor);
        Task UpdateAsync(Conductor conductor);


        Task<Conductor?> GetViajesAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
