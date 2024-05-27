namespace Server_API.Models.WinFormsModels
{
    public class PaymentBillAccountantViewModel
    {
        public int PaymentBillId { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueToDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}
