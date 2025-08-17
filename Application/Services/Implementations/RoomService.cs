using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Room>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Room?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Room entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Room entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<Room>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<Room?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(Room entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(Room entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
