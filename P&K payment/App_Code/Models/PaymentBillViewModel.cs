using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

/// <summary>
/// Summary description for PaymentBillViewModel
/// </summary>
public class PaymentBillViewModel
{
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
    [JsonPropertyName("paymentReceipt")]
    public int? Receipt { get; set; }
    [JsonPropertyName("paymentStatus")]
    public string PaymentStatus { get; set; }

}