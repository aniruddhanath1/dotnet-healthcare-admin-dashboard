using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IShiftService
    {
        Task<IEnumerable<Shift>> GetAllAsync();
        Task<Shift?> GetByIdAsync(int id);
        Task AddAsync(ShiftDto entity);
        Task UpdateAsync(ShiftDto entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Shift>> GetAllMongoAsync();
        Task<Shift?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Shift entity);
        Task UpdateMongoAsync(Shift entity);
        Task DeleteMongoAsync(string id);
    }
}
