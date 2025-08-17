using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface INurseRepository
    {
        Task<IEnumerable<Nurse>> GetAllAsync();
        Task<Nurse> GetByIdAsync(int id);
        Task AddAsync(Nurse nurse);
        Task UpdateAsync(Nurse nurse);
        Task DeleteAsync(int id);
    }
}
