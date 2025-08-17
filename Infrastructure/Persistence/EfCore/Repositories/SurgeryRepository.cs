using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Repositories.EfCore
{
    public class SurgeryRepository : ISurgeryRepository
    {
        private readonly AppDbContext _context;

        public SurgeryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Surgery>> GetAllAsync()
        {
            return await _context.Surgeries.ToListAsync();
        }

        public async Task<Surgery?> GetByIdAsync(int id)
        {
            return await _context.Surgeries.FindAsync(id);
        }

        public async Task AddAsync(Surgery entity)
        {
            await _context.Surgeries.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Surgery entity)
        {
            _context.Surgeries.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Surgeries.FindAsync(id);
            if (entity != null)
            {
                _context.Surgeries.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
