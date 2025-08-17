using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly AppDbContext _context;

        public VisitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visit>> GetAllAsync()
        {
            return await _context.Visits.ToListAsync();
        }

        public async Task<Visit?> GetByIdAsync(int id)
        {
            return await _context.Visits.FindAsync(id);
        }

        public async Task AddAsync(Visit entity)
        {
            await _context.Visits.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Visit entity)
        {
            _context.Visits.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Visits.FindAsync(id);
            if (entity != null)
            {
                _context.Visits.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
