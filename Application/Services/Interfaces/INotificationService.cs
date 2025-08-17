using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification?> GetByIdAsync(int id);
        Task AddAsync(Notification entity);
        Task UpdateAsync(Notification entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Notification>> GetAllMongoAsync();
        Task<Notification?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Notification entity);
        Task UpdateMongoAsync(Notification entity);
        Task DeleteMongoAsync(string id);
    }
}
