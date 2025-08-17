using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Referrals")]
    public class Referral
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("patientId")]
        public Guid PatientId { get; set; }
        [BsonElement("fromDoctorId")]
        public Guid FromDoctorId { get; set; }
        [BsonElement("toDoctorId")]
        public Guid ToDoctorId { get; set; }
        [BsonElement("reason")]
        public string Reason { get; set; }
        [BsonElement("date")]
        public string Date { get; set; }
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
