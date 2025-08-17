using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("dob")]
        public DateTime DOB { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("medicalRecordNumber")]
        public string MedicalRecordNumber { get; set; }
        
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
