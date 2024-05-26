using Server_API.Models.WinFormsModels;

namespace Server_API.Services.FilterService
{
    public interface IFilterService
    {
        public List<PaymentBillAccountantViewModel> OrderByPaymentBillId(string username);
        public List<PaymentBillAccountantViewModel> OrderByServiceName(string username);
        public List<PaymentBillAccountantViewModel> OrderByAmount(string username);
        public List<PaymentBillAccountantViewModel> OrderByIssueDate(string username);
        public List<PaymentBillAccountantViewModel> OrderByDueToDate(string username);
        public List<PaymentBillAccountantViewModel> OrderByPaymentDate(string username);
        public List<PaymentBillAccountantViewModel> OrderByPaymentStatus(string username);
    }
}
