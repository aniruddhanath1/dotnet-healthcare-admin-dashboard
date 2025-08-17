using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class InsuranceProviderRepository : IInsuranceProviderRepository
    {
        private readonly AppDbContext _context;
        public InsuranceProviderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InsuranceProvider>> GetAllAsync() => await _context.InsuranceProviders.ToListAsync();
        public async Task<InsuranceProvider> GetByIdAsync(int id) => await _context.InsuranceProviders.FindAsync(id);
        public async Task<InsuranceProvider> AddAsync(InsuranceProvider provider)
        {
            _context.InsuranceProviders.Add(provider);
            await _context.SaveChangesAsync();
            return provider;
        }
        public async Task<InsuranceProvider> UpdateAsync(InsuranceProvider provider)
        {
            _context.InsuranceProviders.Update(provider);
            await _context.SaveChangesAsync();
            return provider;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.InsuranceProviders.FindAsync(id);
            if (entity == null) return false;
            _context.InsuranceProviders.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
