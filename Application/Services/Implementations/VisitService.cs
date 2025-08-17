using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _repository;
        public VisitService(IVisitRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Visit>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Visit?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Visit entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Visit entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<Visit>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<Visit?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(Visit entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(Visit entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
