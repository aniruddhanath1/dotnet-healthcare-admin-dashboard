using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IAppointmentMongoRepository _mongoRepo;
        public AppointmentService(IAppointmentRepository repository, IAppointmentMongoRepository mongoRepo)
        {
            _repository = repository;
            _mongoRepo = mongoRepo;
        }
        public async Task<IEnumerable<Appointment>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Appointment?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Appointment entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Appointment entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Appointment>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Appointment> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Appointment> AddMongoAsync(Appointment entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Appointment> UpdateMongoAsync(Appointment entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
