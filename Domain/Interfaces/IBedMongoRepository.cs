using dotnet_admin_dashboard.Domain.Entities;

namespace DotNetAdminPanel.Domain.Interfaces
{
    public interface IBedMongoRepository
    {
        // MongoDB specific repository interface for Bed
        Task<IEnumerable<Bed>> GetAllAsync();

        Task<Bed> GetByIdAsync(Guid id);

        Task<Bed> AddAsync(Bed bed);

        Task<Bed> UpdateAsync(Bed bed);

        Task<bool> DeleteAsync(Guid id);
    }
}
