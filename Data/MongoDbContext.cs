using MongoDB.Driver;
using dotnet_admin_dashboard.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace dotnet_admin_dashboard.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("YourDbName");
        }
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        // Add other collections here
    }
}
