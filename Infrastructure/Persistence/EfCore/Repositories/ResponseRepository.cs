using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly AppDbContext _context;
        public ResponseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Response>> GetAllAsync() => await _context.Responses.ToListAsync();
        public async Task<Response> GetByIdAsync(string requestId) => await _context.Responses.FindAsync(requestId);
        public async Task<Response> AddAsync(Response response)
        {
            _context.Responses.Add(response);
            await _context.SaveChangesAsync();
            return response;
        }
        public async Task<Response> UpdateAsync(Response response)
        {
            _context.Responses.Update(response);
            await _context.SaveChangesAsync();
            return response;
        }
        public async Task<bool> DeleteAsync(string requestId)
        {
            var entity = await _context.Responses.FindAsync(requestId);
            if (entity == null) return false;
            _context.Responses.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
