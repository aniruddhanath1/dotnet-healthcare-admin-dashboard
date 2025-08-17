using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class ErrorResponseRepository : IErrorResponseRepository
    {
        private readonly AppDbContext _context;
        public ErrorResponseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ErrorResponse>> GetAllAsync() => await _context.ErrorResponses.ToListAsync();
        public async Task<ErrorResponse> GetByIdAsync(int id) => await _context.ErrorResponses.FindAsync(id);
        public async Task<ErrorResponse> AddAsync(ErrorResponse errorResponse)
        {
            _context.ErrorResponses.Add(errorResponse);
            await _context.SaveChangesAsync();
            return errorResponse;
        }
        public async Task<ErrorResponse> UpdateAsync(ErrorResponse errorResponse)
        {
            _context.ErrorResponses.Update(errorResponse);
            await _context.SaveChangesAsync();
            return errorResponse;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ErrorResponses.FindAsync(id);
            if (entity == null) return false;
            _context.ErrorResponses.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
