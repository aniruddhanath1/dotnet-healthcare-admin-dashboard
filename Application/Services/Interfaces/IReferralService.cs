using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IReferralService
    {
        Task<IEnumerable<Referral>> GetAllAsync();
        Task<Referral?> GetByIdAsync(int id);
        Task AddAsync(ReferralDto entity);
        Task UpdateAsync(ReferralDto entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Referral>> GetAllMongoAsync();
        Task<Referral?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Referral entity);
        Task UpdateMongoAsync(Referral entity);
        Task DeleteMongoAsync(string id);
    }
}
