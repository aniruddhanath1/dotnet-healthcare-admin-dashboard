using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Shifts")]
    public class Shift
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public string Id { get; set; }
        [BsonElement("staffId")]
        public int StaffId { get; set; }
        [BsonElement("startTime")]
        public DateTime StartTime { get; set; }
        [BsonElement("endTime")]
        public DateTime EndTime { get; set; }
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
