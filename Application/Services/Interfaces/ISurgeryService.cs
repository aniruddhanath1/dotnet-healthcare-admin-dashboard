using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface ISurgeryService
    {
        Task<IEnumerable<Surgery>> GetAllAsync();
        Task<Surgery?> GetByIdAsync(int id);
        Task AddAsync(Surgery entity);
        Task UpdateAsync(Surgery entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Surgery>> GetAllMongoAsync();
        Task<Surgery?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Surgery entity);
        Task UpdateMongoAsync(Surgery entity);
        Task DeleteMongoAsync(string id);
    }
}
