using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ISurgeryRepository
    {
        Task<IEnumerable<Surgery>> GetAllAsync();
        Task<Surgery> GetByIdAsync(int id);
        Task<Surgery> AddAsync(Surgery surgery);
        Task<Surgery> UpdateAsync(Surgery surgery);
        Task<bool> DeleteAsync(int id);
    }
}
