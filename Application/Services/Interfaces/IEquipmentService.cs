using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(int id);
        Task<Equipment> AddAsync(EquipmentDto equipment);
        Task<Equipment> UpdateAsync(EquipmentDto equipment);
        Task<bool> DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Equipment>> GetAllMongoAsync();
        Task<Equipment> GetByIdMongoAsync(int id);
        Task<Equipment> AddMongoAsync(Equipment entity);
        Task<Equipment> UpdateMongoAsync(Equipment entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
