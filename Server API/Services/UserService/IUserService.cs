using Server_API.Models.Entity;
using Server_API.Models.WebFormsModels;

namespace Server_API.Services.UserService
{
    public interface IUserService
    {
        public bool isRegistered(Client client);
        public bool isLoggedIn(string username);
        public List<PaymentBillUserViewModel> GetClientPaymentBills(string username);
        public bool PayTheBill(int billId);
        public bool UpdateReceipt(int billId, int receipt);
    }
}
