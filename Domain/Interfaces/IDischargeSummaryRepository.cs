using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IDischargeSummaryRepository
    {
        // EfCore/Mongo pattern
        Task<IEnumerable<DischargeSummary>> GetAllAsync();
        Task<DischargeSummary> GetByIdAsync(int id);
        Task<DischargeSummary> AddAsync(DischargeSummary summary);
        Task<DischargeSummary> UpdateAsync(DischargeSummary summary);
        Task<bool> DeleteAsync(int id);
    }
}
