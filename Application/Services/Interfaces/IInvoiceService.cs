using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task AddAsync(Invoice entity);
        Task UpdateAsync(Invoice entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Invoice>> GetAllMongoAsync();
        Task<Invoice?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Invoice entity);
        Task UpdateMongoAsync(Invoice entity);
        Task DeleteMongoAsync(string id);
    }
}
