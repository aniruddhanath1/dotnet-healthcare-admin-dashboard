using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Application.DTOs
{
    [Table("Responses")]
    public class ResponseDto
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string RequestId { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("success")]
        public bool Success { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }

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
