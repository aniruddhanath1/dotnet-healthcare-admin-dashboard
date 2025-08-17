using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(UserDto entity);
        Task UpdateAsync(UserDto entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<User>> GetAllMongoAsync();
        Task<User?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(User entity);
        Task UpdateMongoAsync(User entity);
        Task DeleteMongoAsync(string id);
    }
}
