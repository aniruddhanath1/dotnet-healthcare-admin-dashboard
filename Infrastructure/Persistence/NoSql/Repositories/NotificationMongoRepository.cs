using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class NotificationMongoRepository : INotificationRepository
    {
        private readonly IMongoCollection<Notification> _collection;
        public NotificationMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Notification>("Notifications");
        }
        public async Task<IEnumerable<Notification>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Notification> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Notification> AddAsync(Notification notification)
        {
            await _collection.InsertOneAsync(notification);
            return notification;
        }
        public async Task<Notification> UpdateAsync(Notification notification)
        {
            await _collection.ReplaceOneAsync(e => e.Id == notification.Id, notification);
            return notification;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
