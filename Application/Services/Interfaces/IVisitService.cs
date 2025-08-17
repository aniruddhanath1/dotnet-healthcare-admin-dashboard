using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IVisitService
    {
        Task<IEnumerable<Visit>> GetAllAsync();
        Task<Visit?> GetByIdAsync(int id);
        Task AddAsync(Visit entity);
        Task UpdateAsync(Visit entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Visit>> GetAllMongoAsync();
        Task<Visit?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Visit entity);
        Task UpdateMongoAsync(Visit entity);
        Task DeleteMongoAsync(string id);
    }
}
