using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IAmbulanceService
    {

        // ADO.NET / EF Core methods
        Task<IEnumerable<Ambulance>> GetAllAsync();
        Task<Ambulance?> GetByIdAsync(string id);
        Task AddAsync(AmbulanceDto entity);
        Task UpdateAsync(AmbulanceDto entity);
        Task DeleteAsync(string id);
        
        // MongoDB/model-based methods
        Task<IEnumerable<Ambulance>> GetAllMongoAsync();
        Task<Ambulance> GetByIdMongoAsync(string id);
        Task<Ambulance> AddMongoAsync(Ambulance entity);
        Task<Ambulance> UpdateMongoAsync(Ambulance entity);
        Task<bool> DeleteMongoAsync(string id);
    }
}
