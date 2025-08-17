using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IAppointmentMongoRepository
    {
        // MongoDB specific repository interface for Appointment
        Task<IEnumerable<Appointment>> GetAllAsync();

        Task<Appointment> GetByIdAsync(Guid id);

        Task<Appointment> AddAsync(Appointment appointment);

        Task<Appointment> UpdateAsync(Appointment appointment);

        Task<bool> DeleteAsync(Guid id);
    }
}
