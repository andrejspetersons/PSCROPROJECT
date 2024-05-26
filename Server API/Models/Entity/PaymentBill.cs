namespace Server_API.Models.Entity
{
    public class PaymentBill
    {
        public int Id { get; set; }
        public CompanyService Service { get; set; }
        public Client Client { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueToDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentReceipt { get; set; }
        public Status PaymentStatus { get; set; } = Status.NOTPAID;
    }
}
