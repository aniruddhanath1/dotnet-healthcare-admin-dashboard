using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<User?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(User entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(User entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<User>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<User?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(User entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(User entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
