using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_admin_dashboard.Domain.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        [BsonElement("invoiceId")]
        public int InvoiceId { get; set; }

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("transactionDate")]
        public DateTime TransactionDate { get; set; }

        [BsonElement("paymentMethod")]
        public string PaymentMethod { get; set; } // e.g., BankTransfer, CreditCard, Cash

        [BsonElement("bankName")]
        public string? BankName { get; set; }

        [BsonElement("accountNumber")]
        public string? AccountNumber { get; set; }

        [BsonElement("transactionReference")]
        public string? TransactionReference { get; set; }

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
