using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IAmbulanceAdoRepository
    {
        // ADO.NET specific repository interface for Ambulance
        Task<IEnumerable<Ambulance>> GetAllAsync();

        Task<Ambulance> GetByIdAsync(Guid id);

        Task<Ambulance> AddAsync(Ambulance ambulance);

        Task<Ambulance> UpdateAsync(Ambulance ambulance);

        Task<bool> DeleteAsync(Guid id);
    }
}
