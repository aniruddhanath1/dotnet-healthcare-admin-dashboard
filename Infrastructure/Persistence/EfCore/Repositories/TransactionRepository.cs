using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetAllAsync() => await _context.Transactions.ToListAsync();
        public async Task<Transaction> GetByIdAsync(int id) => await _context.Transactions.FindAsync(id);
        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Transactions.FindAsync(id);
            if (entity == null) return false;
            _context.Transactions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
