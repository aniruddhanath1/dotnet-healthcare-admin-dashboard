
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("ErrorResponses")]
    public class ErrorResponse : Response
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("errorCode")]
        public string ErrorCode { get; set; }

        [BsonElement("details")]
        public string Details { get; set; }

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
