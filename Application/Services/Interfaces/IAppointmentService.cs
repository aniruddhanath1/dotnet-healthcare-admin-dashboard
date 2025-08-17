using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task AddAsync(Appointment entity);
        Task UpdateAsync(Appointment entity);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Appointment>> GetAllMongoAsync();
        Task<Appointment> GetByIdMongoAsync(int id);
        Task<Appointment> AddMongoAsync(Appointment entity);
        Task<Appointment> UpdateMongoAsync(Appointment entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
