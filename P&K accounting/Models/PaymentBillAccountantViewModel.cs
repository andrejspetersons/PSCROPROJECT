using System.Text.Json.Serialization;

namespace P_K_accounting.Models
{
    public class PaymentBillAccountantViewModel
    {
        [JsonPropertyName("paymentBillId")]
        public int PaymentBillId { get; set; }
        [JsonPropertyName("serviceName")]
        public string ServiceName { get; set; }
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("issueDate")]
        public DateTime IssueDate { get; set; }
        [JsonPropertyName("dueToDate")]
        public DateTime DueToDate { get; set; }
        [JsonPropertyName("paymentDate")]
        public DateTime? PaymentDate { get; set; }
        [JsonPropertyName("paymentStatus")]
        public string PaymentStatus { get; set; }

    }
}
