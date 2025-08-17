using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class SuccessResponseRepository : ISuccessResponseRepository
    {
        private readonly AppDbContext _context;
        public SuccessResponseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SuccessResponse>> GetAllAsync() => await _context.SuccessResponses.ToListAsync();
        public async Task<SuccessResponse> GetByIdAsync(int id) => await _context.SuccessResponses.FindAsync(id);
        public async Task<SuccessResponse> AddAsync(SuccessResponse successResponse)
        {
            _context.SuccessResponses.Add(successResponse);
            await _context.SaveChangesAsync();
            return successResponse;
        }
        public async Task<SuccessResponse> UpdateAsync(SuccessResponse successResponse)
        {
            _context.SuccessResponses.Update(successResponse);
            await _context.SaveChangesAsync();
            return successResponse;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.SuccessResponses.FindAsync(id);
            if (entity == null) return false;
            _context.SuccessResponses.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
