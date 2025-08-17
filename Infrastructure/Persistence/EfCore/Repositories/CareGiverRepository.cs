using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class CareGiverRepository : ICareGiverRepository
    {
        private readonly AppDbContext _context;
        public CareGiverRepository(AppDbContext context) { _context = context; }
        public async Task<IEnumerable<CareGiver>> GetAllAsync() => await _context.CareGivers.ToListAsync();
        public async Task<CareGiver> GetByIdAsync(int id) => await _context.CareGivers.FindAsync(id);
        public async Task AddAsync(CareGiver careGiver) { _context.CareGivers.Add(careGiver); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(CareGiver careGiver) { _context.CareGivers.Update(careGiver); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var entity = await _context.CareGivers.FindAsync(id); if (entity != null) { _context.CareGivers.Remove(entity); await _context.SaveChangesAsync(); } }
    }
}
