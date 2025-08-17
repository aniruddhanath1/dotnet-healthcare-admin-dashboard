using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class NotificationAdoRepository : INotificationRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public NotificationAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Notifications";
                var result = await unitOfWork.Connection.QueryAsync<Notification>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<Notification> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Notifications WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<Notification>(sql, new { Id = id }, unitOfWork.Transaction);
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

        public async Task<Notification> AddAsync(Notification notification, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO Notifications (UserId, Message, CreatedAt, IsRead, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@UserId, @Message, @CreatedAt, @IsRead, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                notification.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, notification, unitOfWork.Transaction);
                Commit(unitOfWork);
                return notification;
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

        public async Task<Notification> UpdateAsync(Notification notification, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE Notifications SET UserId=@UserId, Message=@Message, CreatedAt=@CreatedAt, IsRead=@IsRead, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, notification, unitOfWork.Transaction);
                Commit(unitOfWork);
                return notification;
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
                var sql = "DELETE FROM Notifications WHERE Id=@Id";
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
