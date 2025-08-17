using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Supplies")]
    public class Supply
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [Required]
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("unit")]
        public string Unit { get; set; }
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
