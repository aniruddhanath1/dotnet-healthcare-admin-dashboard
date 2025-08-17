using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class DischargeSummaryRepository : IDischargeSummaryRepository
    {
        private readonly AppDbContext _context;
        public DischargeSummaryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DischargeSummary>> GetAllAsync() => await _context.DischargeSummaries.ToListAsync();
        public async Task<DischargeSummary> GetByIdAsync(int id) => await _context.DischargeSummaries.FindAsync(id);
        public async Task<DischargeSummary> AddAsync(DischargeSummary summary)
        {
            _context.DischargeSummaries.Add(summary);
            await _context.SaveChangesAsync();
            return summary;
        }
        public async Task<DischargeSummary> UpdateAsync(DischargeSummary summary)
        {
            _context.DischargeSummaries.Update(summary);
            await _context.SaveChangesAsync();
            return summary;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DischargeSummaries.FindAsync(id);
            if (entity == null) return false;
            _context.DischargeSummaries.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
