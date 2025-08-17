using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(RoomDto entity);
        Task UpdateAsync(RoomDto entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Room>> GetAllMongoAsync();
        Task<Room?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Room entity);
        Task UpdateMongoAsync(Room entity);
        Task DeleteMongoAsync(string id);
    }
}
