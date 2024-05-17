using Server_API.Models.WinFormsModels;

namespace Server_API.Services.AccountantService
{
    public interface IAccountantService
    {
        public List<string> GetAllClients();
        public void AddPaymentBill(string username, PaymentBillAccountantViewModel pbv);
        public List<PaymentBillAccountantViewModel> GetPaymentBillsByClientLogin(string username);
        public bool UpdatePaymentBillById(int id, PaymentBillAccountantViewModel pbv);
        public bool DeletePaymnentBillById(int id);
    }
}
