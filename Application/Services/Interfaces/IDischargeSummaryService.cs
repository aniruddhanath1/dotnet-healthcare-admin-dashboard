using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IDischargeSummaryService
    {
        Task<IEnumerable<DischargeSummary>> GetAllAsync();
        Task<DischargeSummary?> GetByIdAsync(int id);
        Task AddAsync(DischargeSummary entity);
        Task UpdateAsync(DischargeSummary entity);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<DischargeSummary>> GetAllMongoAsync();
        Task<DischargeSummary> GetByIdMongoAsync(int id);
        Task<DischargeSummary> AddMongoAsync(DischargeSummary entity);
        Task<DischargeSummary> UpdateMongoAsync(DischargeSummary entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
