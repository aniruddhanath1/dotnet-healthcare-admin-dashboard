using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ISupplyRepository
    {
        Task<IEnumerable<Supply>> GetAllAsync();
        Task<Supply> GetByIdAsync(int id);
        Task<Supply> AddAsync(Supply supply);
        Task<Supply> UpdateAsync(Supply supply);
        Task<bool> DeleteAsync(int id);
    }
}
