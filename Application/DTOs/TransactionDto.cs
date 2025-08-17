using System;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Application.DTOs
{
    public class TransactionDto
    {
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }

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