using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Application.DTOs
{
    [Table("Surgeries")]
    public class SurgeryDto
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [BsonElement("patientId")]
        public int PatientId { get; set; }
        [BsonElement("doctorId")]
        public int DoctorId { get; set; }
        [BsonElement("surgeryType")]
        public string SurgeryType { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("notes")]
        public string Notes { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }

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
