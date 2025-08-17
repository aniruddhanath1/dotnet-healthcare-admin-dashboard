using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Prescriptions")]
    public class Prescription
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("patientId")]
        public Guid PatientId { get; set; }
        [BsonElement("doctorId")]
        public Guid DoctorId { get; set; }
        [BsonElement("medicationId")]
        public Guid MedicationId { get; set; }
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
