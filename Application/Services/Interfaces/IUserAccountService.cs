using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccount>> GetAllAsync();
        Task<UserAccount> GetByIdAsync(int id);
        Task<UserAccount> AddAsync(UserAccountDto userAccount);
        Task<UserAccount> UpdateAsync(UserAccountDto userAccount);
        Task<bool> DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<UserAccount>> GetAllMongoAsync();
        Task<UserAccount?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(UserAccount entity);
        Task UpdateMongoAsync(UserAccount entity);
        Task DeleteMongoAsync(string id);
    }
}
