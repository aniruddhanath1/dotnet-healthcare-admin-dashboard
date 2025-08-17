using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class TransactionAdoRepository : ITransactionRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public TransactionAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Transactions";
                var result = await unitOfWork.Connection.QueryAsync<Transaction>(sql, transaction: unitOfWork.Transaction);
                Commit(unitOfWork);
                return result;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<Transaction> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Transactions WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<Transaction>(sql, new { Id = id }, unitOfWork.Transaction);
                Commit(unitOfWork);
                return result;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<Transaction> AddAsync(Transaction transaction, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO Transactions (InvoiceId, Amount, TransactionDate, PaymentMethod, BankName, AccountNumber, TransactionReference, Status, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id
                        VALUES (@InvoiceId, @Amount, @TransactionDate, @PaymentMethod, @BankName, @AccountNumber, @TransactionReference, @Status, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                transaction.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, transaction, unitOfWork.Transaction);
                Commit(unitOfWork);
                return transaction;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE Transactions SET InvoiceId=@InvoiceId, Amount=@Amount, TransactionDate=@TransactionDate, PaymentMethod=@PaymentMethod, BankName=@BankName, AccountNumber=@AccountNumber, TransactionReference=@TransactionReference, Status=@Status, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, transaction, unitOfWork.Transaction);
                Commit(unitOfWork);
                return transaction;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<bool> DeleteAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "DELETE FROM Transactions WHERE Id=@Id";
                var affected = await unitOfWork.Connection.ExecuteAsync(sql, new { Id = id }, unitOfWork.Transaction);
                Commit(unitOfWork);
                return affected > 0;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        // Transaction management methods
        public void Commit(AdoNetUnitOfWork unitOfWork)
        {
            unitOfWork.Commit();
        }

        public void Rollback(AdoNetUnitOfWork unitOfWork)
        {
            unitOfWork.Rollback();
        }

        public void DisposeUnitOfWork(AdoNetUnitOfWork unitOfWork)
        {
            unitOfWork.Dispose();
        }
    }
}
