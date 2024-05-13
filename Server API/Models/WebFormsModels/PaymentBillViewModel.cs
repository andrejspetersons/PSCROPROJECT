using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Server_API.Models.WebFormsModels
{
    public class PaymentBillViewModel
    {
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueToDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentReceipt { get; set; }
        public string PaymentStatus { get; set; }
        //represents the shape of GridView record in ASP.NET WEB FORMS
    }
}
