using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Application.DTOs
{
    [Table("Prescriptions")]
    public class PrescriptionDto
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [BsonElement("patientId")]
        public int PatientId { get; set; }
        [BsonElement("doctorId")]
        public int DoctorId { get; set; }
        [BsonElement("medicationId")]
        public int MedicationId { get; set; }
        [BsonElement("datePrescribed")]
        public DateTime DatePrescribed { get; set; }
        [BsonElement("dosage")]
        public string Dosage { get; set; }

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
