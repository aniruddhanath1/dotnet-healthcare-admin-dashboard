using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> GetAllAsync();
        Task<MedicalRecord> GetByIdAsync(int id);
        Task<MedicalRecord> AddAsync(MedicalRecord record);
        Task<MedicalRecord> UpdateAsync(MedicalRecord record);
        Task<bool> DeleteAsync(int id);
    }
}
