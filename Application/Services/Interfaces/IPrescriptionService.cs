using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetAllAsync();
        Task<Prescription?> GetByIdAsync(int id);
        Task AddAsync(PrescriptionDto entity);
        Task UpdateAsync(PrescriptionDto entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Prescription>> GetAllMongoAsync();
        Task<Prescription?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Prescription entity);
        Task UpdateMongoAsync(Prescription entity);
        Task DeleteMongoAsync(string id);
    }
}
