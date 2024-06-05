using Server_API.Models.Entity;
using Server_API.Models.WinFormsModels;

namespace Server_API.Services.AccountantService
{
    public interface IAccountantService
    {
        public List<string> GetAllClientsUserNames();
        public PaymentBill AddPaymentBill(string username, PaymentBillAccountantViewModel pbv);
        public List<PaymentBillAccountantViewModel> GetPaymentBillsByClientLogin(string username);
        public PaymentBill UpdatePaymentBillById(int id, PaymentBillAccountantViewModel pbv);
        public bool DeletePaymnentBillById(int id);
    }
}
