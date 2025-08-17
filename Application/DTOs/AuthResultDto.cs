using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Application.DTOs
{
    [Table("AuthResults")]
    public class AuthResultDto
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [BsonElement("success")]
        public bool Success { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
        [BsonElement("token")]
        public string Token { get; set; }

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
