using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly AppDbContext _context;
        public NurseRepository(AppDbContext context) { _context = context; }
        public async Task<IEnumerable<Nurse>> GetAllAsync() => await _context.Nurses.ToListAsync();
        public async Task<Nurse> GetByIdAsync(int id) => await _context.Nurses.FindAsync(id);
        public async Task AddAsync(Nurse nurse) { _context.Nurses.Add(nurse); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Nurse nurse) { _context.Nurses.Update(nurse); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var entity = await _context.Nurses.FindAsync(id); if (entity != null) { _context.Nurses.Remove(entity); await _context.SaveChangesAsync(); } }
    }
}
