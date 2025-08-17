using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("userId")]
        public Guid UserId { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("isRead")]
        public bool IsRead { get; set; }
        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }
        [BsonElement("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [BsonElement("lastModifiedBy")]
        public string LastModifiedBy { get; set; }
        [BsonElement("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }
    }
}
