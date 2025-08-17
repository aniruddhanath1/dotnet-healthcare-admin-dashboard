using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Application.DTOs
{
    [Table("LabTests")]
    public class LabTestDto
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [BsonElement("patientId")]
        public int PatientId { get; set; }
        [BsonElement("testType")]
        public string TestType { get; set; }
        [BsonElement("result")]
        public string Result { get; set; }
        [BsonElement("dateConducted")]
        public DateTime DateConducted { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }

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
