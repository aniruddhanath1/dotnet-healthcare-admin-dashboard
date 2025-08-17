using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ICareGiverRepository
    {
        Task<IEnumerable<CareGiver>> GetAllAsync();
        Task<CareGiver> GetByIdAsync(int id);
        Task AddAsync(CareGiver careGiver);
        Task UpdateAsync(CareGiver careGiver);
        Task DeleteAsync(int id);
    }
}
