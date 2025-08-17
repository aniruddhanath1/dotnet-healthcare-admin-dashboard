using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(int id);
        Task<Equipment> AddAsync(Equipment equipment);
        Task<Equipment> UpdateAsync(Equipment equipment);
        Task<bool> DeleteAsync(int id);
    }
}
