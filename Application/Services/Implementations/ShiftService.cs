using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _repository;
        public ShiftService(IShiftRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Shift>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Shift?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Shift entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Shift entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<Shift>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<Shift?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(Shift entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(Shift entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
