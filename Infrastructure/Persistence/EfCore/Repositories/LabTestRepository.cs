using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class LabTestRepository : ILabTestRepository
    {
        private readonly AppDbContext _context;
        public LabTestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LabTest>> GetAllAsync() => await _context.LabTests.ToListAsync();
        public async Task<LabTest> GetByIdAsync(int id) => await _context.LabTests.FindAsync(id);
        public async Task<LabTest> AddAsync(LabTest test)
        {
            _context.LabTests.Add(test);
            await _context.SaveChangesAsync();
            return test;
        }
        public async Task<LabTest> UpdateAsync(LabTest test)
        {
            _context.LabTests.Update(test);
            await _context.SaveChangesAsync();
            return test;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.LabTests.FindAsync(id);
            if (entity == null) return false;
            _context.LabTests.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
